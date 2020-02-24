using System.Collections.Generic;
using System.Threading.Tasks;
using Searchfight.Core.Entities;

namespace Searchfight.Core.Services
{
	public interface ISearchService
	{
		Task<IEnumerable<SearchfightSearchResult>> SearchfightSearch(string[] searchQueries);
	}
}