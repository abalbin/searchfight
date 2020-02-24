using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Searchfight.Core.Interfaces;

namespace Searchfight.Infra.SearchClients
{
	public class BingSearchClient : ISearchClient
	{
		// the azure bing search client
		private readonly WebSearchClient _searchClient;
		public BingSearchClient(string apiKey)
		{
			// initialize the search client
			_searchClient = new WebSearchClient(new ApiKeyServiceClientCredentials(apiKey));
		}
		public async Task<long> PerformSearch(string query)
		{
			var bingResult = await _searchClient.Web.SearchAsync(query);

			// return the estimated matches, if null return 0
			return bingResult.WebPages.TotalEstimatedMatches ?? 0;
		}
	}
}