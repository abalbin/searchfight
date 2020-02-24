using System;
using System.Linq;
using Searchfight.Core.Entities;
using Searchfight.Core.Services;
using Xunit;
using Moq;
using Searchfight.Infra.SearchClients;
using Searchfight.Core.Interfaces;

namespace Searchfight.Test
{
	public class SearchServiceTest
	{
		[Fact]
		public async void SearchfightSearchShouldThrowArgumentNullException()
		{
			var searchService = new SearchService(null, null);

			await Assert.ThrowsAsync<ArgumentNullException>(() => searchService.SearchfightSearch(null));
		}

		[Fact]
		public async void SearchfightSearchShouldThrowArgumentOutOfRangeException()
		{
			var searchService = new SearchService(null, null);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => searchService.SearchfightSearch(new string[] { }));
		}

		[Fact]
		public async void SearchfightSearchShouldReturn2ItemsInSuccessState()
		{
			var searchQueries = new string[] { "some:query:1" };
			// mock the services
			var mockGoogleSearchClient = new Mock<ISearchClient>();
			mockGoogleSearchClient.Setup(x => x.PerformSearch(searchQueries[0])).ReturnsAsync(2);

			var mockBingSearchClient = new Mock<ISearchClient>();
			mockBingSearchClient.Setup(x => x.PerformSearch(searchQueries[0])).ReturnsAsync(4);

			var searchService = new SearchService(mockGoogleSearchClient.Object, mockBingSearchClient.Object);

			var searchResults = await searchService.SearchfightSearch(searchQueries);

			// var searchClient = new Mock<ISear
			Assert.Equal(2, searchResults.Count());
			Assert.Equal(true, searchResults.All(r => r.SearchStatus == SearchfightSearchStatus.Success));
		}

		[Fact]
		public async void SearchfightSearchShouldReturn1ItemInSuccessStateAnd1InErrorState()
		{
			var searchQueries = new string[] { "some:query:1" };
			// mock the services
			var mockGoogleSearchClient = new Mock<ISearchClient>();
			mockGoogleSearchClient.Setup(x => x.PerformSearch(searchQueries[0])).ReturnsAsync(2);

			var mockBingSearchClient = new Mock<ISearchClient>();
			mockBingSearchClient.Setup(x => x.PerformSearch(searchQueries[0])).ThrowsAsync(new Exception("An error ocurred with Bing search service"));

			var searchService = new SearchService(mockGoogleSearchClient.Object, mockBingSearchClient.Object);

			var searchResults = await searchService.SearchfightSearch(searchQueries);

			// var searchClient = new Mock<ISear
			Assert.Equal(2, searchResults.Count());
			Assert.Equal(false, searchResults.All(r => r.SearchStatus == SearchfightSearchStatus.Success));
			Assert.Equal(1, searchResults.Where(r => r.SearchStatus == SearchfightSearchStatus.Success).Count());
			Assert.Equal(1, searchResults.Where(r => r.SearchStatus == SearchfightSearchStatus.Error).Count());
		}
	}
}
