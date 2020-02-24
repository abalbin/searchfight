using System.Threading.Tasks;

namespace Searchfight.Infra.SearchClients
{
	public interface ISearchClient
	{
		Task<int> PerformSearch(string query);
	}
}