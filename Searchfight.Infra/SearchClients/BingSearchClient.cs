using System.Threading.Tasks;

namespace Searchfight.Infra.SearchClients
{
	public class BingSearchClient : BaseSearchClient, ISearchClient
	{

		public async Task<int> PerformSearch(string query)
		{
			return 225;
		}
	}
}