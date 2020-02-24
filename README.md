# Searchfight

This app will let you know which pre configured search engine has the highest number of search results for a query or set of queries.

## Prerequisites

* .Net Core 3.1 SDK [Click here to download the installer](https://dotnet.microsoft.com/download)
* Azure Cognitive Services - Bing Search API Key. You can create a trial key [here](https://azure.microsoft.com/en-us/try/cognitive-services/my-apis/?api=bing-web-search-api)

## Installation using VS Code or the CLI (on Windows)

1. Clone this repository
2. Execute `dotnet restore`
3. Go to the Searchfight.ConsoleApp project `cd Searchfight.ConsoleApp/`
4. Execute `dotnet publish -r win-x64 -c Release --self-contained`
5. Go to `cd ./bin/Release/netcoreapp3.1/win-x64/publish/`
6. Perform a search with `Searchfight.ConsoleApp.exe [queries]`. For example: `Searchfight.ConsoleApp.exe .net java "ruby on rails"`

## Debug with the CLI

* Execute the first 3 steps of the last section
* Perform a search with `dotnet run -- [queries]`. For example: `dotnet run -- .net java "ruby on rails"`

## About the search providers

* For Google, the client will do a web scrapping to the Google's site and return the result count from there
* For Bing, the client uses the Bing Search API and returns the estimated result count from there