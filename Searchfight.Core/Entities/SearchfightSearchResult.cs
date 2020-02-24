namespace Searchfight.Core.Entities
{
	public enum SearchfightSearchStatus
	{
		Success,
		Error
	}
	public class SearchfightSearchResult
	{
		public string Query { get; set; }
		public SearchfightSearchStatus SearchStatus { get; set; }
		public string ProviderName { get; set; }
		public int ResultCount { get; set; }
		public string ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
	}
}