using System.Threading.Tasks;

namespace Searchfight.Core.Interfaces
{
	public interface ISearchClient
	{
		Task<long> PerformSearch(string query);
	}
}