using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Searchfight.Core.Entities;
using Searchfight.Core.Interfaces;

namespace Searchfight.Core.Services
{
	public class SearchService : ISearchService
	{
		// set here the name of the providers that you want to use for the fight
		// you must be sure that the provider client is implemented at Searchfight.Infra.SearchClients
		private readonly HashSet<string> _searchProviderNames = new HashSet<string> { "google", "bing" };

		// the search clients will be injected to this class
		private readonly ISearchClient _googleSearchClient;
		private readonly ISearchClient _bingSearchClient;
		public SearchService(ISearchClient googleSearchClient, ISearchClient bingSearchClient)
		{
			_googleSearchClient = googleSearchClient;
			_bingSearchClient = bingSearchClient;
		}

		public async Task<IEnumerable<SearchfightSearchResult>> SearchfightSearch(string[] searchQueries)
		{
			// throw ArgumentNullException if searchQueries is null
			if (searchQueries == null)
			{
				throw new ArgumentNullException(nameof(searchQueries), "The search queries array must exist");
			}

			// throw ArgumentOutOfRangeException if searchQueries is empty
			if (searchQueries.Length == 0)
			{
				throw new ArgumentOutOfRangeException(nameof(searchQueries), "The search queries array must have at least one value");
			}

			var searchfightResultList = new List<SearchfightSearchResult>();
			// Initialize the provider clients
			foreach (var providerName in _searchProviderNames)
			{
				// get the search client form the factory
				var searchClient = CreateSearchClient(providerName);

				// iterate between the queries and perform each search
				foreach (var query in searchQueries)
				{
					try
					{
						var resultCount = await searchClient.PerformSearch(query);
						searchfightResultList.Add(new SearchfightSearchResult
						{
							Query = query,
							ProviderName = providerName,
							ResultCount = resultCount,
							SearchStatus = SearchfightSearchStatus.Success
						});
					}
					catch (System.Exception ex)
					{
						// @todo log the error
						// add the item with the error info, so we can tell the users there was an error with this search
						searchfightResultList.Add(new SearchfightSearchResult
						{
							Query = query,
							ProviderName = providerName,
							SearchStatus = SearchfightSearchStatus.Error,
							ErrorCode = "PerformSearchFailed",
							ErrorMessage = ex.Message
						});
					}

				}
			}

			return searchfightResultList;
		}

		// this is our simple factory
		private ISearchClient CreateSearchClient(string providerName)
		{
			switch (providerName)
			{
				case "google": return _googleSearchClient;
				case "bing": return _bingSearchClient;
				default: return null;
			}
		}
	}
}