using System;
using Searchfight.Core.Services;
using Xunit;

namespace Searchfight.Test
{
	public class SearchServiceTest
	{
		[Fact]
		public async void SearchfightSearchShouldThrowArgumentNullException()
		{
			var searchService = new SearchService();

			await Assert.ThrowsAsync<ArgumentNullException>(() => searchService.SearchfightSearch(null));
		}

		[Fact]
		public async void SearchfightSearchShouldThrowArgumentOutOfRangeException()
		{
			var searchService = new SearchService();

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => searchService.SearchfightSearch(new string[] { }));
		}


	}
}
