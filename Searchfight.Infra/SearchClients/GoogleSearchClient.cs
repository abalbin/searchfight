using System.Threading.Tasks;
using Searchfight.Core.Interfaces;

namespace Searchfight.Infra.SearchClients
{
	public class GoogleSearchClient : ISearchClient
	{

		public async Task<int> PerformSearch(string query)
		{
			return 224;
		}
	}
}