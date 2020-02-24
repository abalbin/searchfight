using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Searchfight.Core.Interfaces;

namespace Searchfight.Infra.SearchClients
{
	public class GoogleSearchClient : ISearchClient
	{

		public async Task<long> PerformSearch(string query)
		{
			var formattedQuery = GetFormattedQuery(query);

			// will do a web scrapping to retrieve the result count estimated number
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");
			var getResult = await httpClient.GetStringAsync(new Uri($"http://google.com/search?q={formattedQuery}&hl=en"));

			// var matches = Regex.Match(crawledPage.Content.Text, @"About \d{1,3}(,\d{3})*(\.\d+)? result");
			var matches = Regex.Match(getResult, @"About \d{1,3}(,\d{3})*(\.\d+)? result");
			if (matches.Success)
			{
				// the match value will be somethong like: About 103,000,000 result
				var splittedWords = matches.Value.Split(' ');

				// remove the commas
				var countText = splittedWords[1].Replace(",", "");

				// convert the text to a valid number
				var count = long.TryParse(countText, out long tempCount) ? tempCount : 0;
				return count;
			}
			return 0;
		}

		// this function will format the query text for making the google web request
		private string GetFormattedQuery(string query)
		{
			// split in words
			var splittedQuery = query.Split(' ');

			if (splittedQuery.Length == 0)
			{
				return null;
			}

			if (splittedQuery.Length == 1)
			{
				return splittedQuery[0];
			}

			// join the words with + char
			return string.Join("+", splittedQuery);

		}
	}
}