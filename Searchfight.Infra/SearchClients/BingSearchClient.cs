using System.Threading.Tasks;
using Searchfight.Core.Interfaces;

namespace Searchfight.Infra.SearchClients
{
	public class BingSearchClient : ISearchClient
	{

		public async Task<int> PerformSearch(string query)
		{
			return 225;
		}
	}
}