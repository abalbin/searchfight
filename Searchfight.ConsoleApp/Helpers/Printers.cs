using System;
using System.Collections.Generic;
using System.Linq;
using Searchfight.Core.Entities;

namespace Searchfight.ConsoleApp
{
	public static class Printers
	{
		public static void PrintSearchfight(IEnumerable<SearchfightSearchResult> searchResults)
		{
			// group the results by query
			var groupedResultsByQuery = searchResults.GroupBy(r => r.Query);

			// iterate the groups and print
			foreach (var queryGroup in groupedResultsByQuery)
			{
				var providersLine = string.Join(" ", queryGroup.Select(q => $"{q.ProviderName}: {q.ResultCount}"));
				Console.WriteLine($"{queryGroup.Key} -> {providersLine}");
			}

			// print the winner query for each provider
			// group by provider
			var groupedResultsByProvider = searchResults.GroupBy(r => r.ProviderName);

			// variable for storing the total winner
			var totalWinner = searchResults.First();

			foreach (var providerGroup in groupedResultsByProvider)
			{
				var providerMaxScoreResult = providerGroup.OrderByDescending(p => p.ResultCount).FirstOrDefault();
				// print the winner query for this provider
				Console.WriteLine($"{providerMaxScoreResult.ProviderName} winner -> {providerMaxScoreResult.Query}");

				// check if this is the total winner
				if (providerMaxScoreResult.ResultCount > totalWinner.ResultCount)
				{
					totalWinner = providerMaxScoreResult;
				}
			}

			// print the total winner
			Console.WriteLine($"Total Winner -> {totalWinner.ProviderName}");
		}
	}
}