using System.Threading.Tasks;

namespace Searchfight.Core.Interfaces
{
	public interface ISearchClient
	{
		Task<int> PerformSearch(string query);
	}
}