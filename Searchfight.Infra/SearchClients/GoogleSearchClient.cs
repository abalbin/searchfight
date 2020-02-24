using System.Threading.Tasks;

namespace Searchfight.Infra.SearchClients
{
	public class GoogleSearchClient : BaseSearchClient, ISearchClient
	{

		public async Task<int> PerformSearch(string query)
		{
			return 224;
		}
	}
}