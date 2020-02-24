using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Searchfight.Core.Entities;
using Searchfight.Core.Services;
using Searchfight.Infra.SearchClients;

namespace Searchfight.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// execute the async main
			MainAsync(args).GetAwaiter().GetResult();
		}

		public static async Task MainAsync(string[] args)
		{
			// check if at least one search query is present
			if (args.Length < 1)
			{
				Console.WriteLine("Please, enter at least one search query");
			}

			// create the search service and inject the search clients
			var searchService = new SearchService(new GoogleSearchClient(), new BingSearchClient("some:bing:api:key"));

			// get the search results
			var searchResults = await searchService.SearchfightSearch(args);

			// print the results
			Printers.PrintSearchfight(searchResults);

			Console.ReadKey();
		}
	}
}
