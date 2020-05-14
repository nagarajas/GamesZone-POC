using GamesZone.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace GamesZone.Services
{
    public class GameService : IGameService
    {
        private RestClient httpClient;
        public GameService()
        {
            httpClient = new RestClient(Constants.API_BASE_URL);
        }

        /// <summary>
        /// Current Game Season
        /// </summary>
        public int Season
        {
            get
            {
                return DateTime.UtcNow.Year;
            }
        }

        /// <summary>
        /// Get all games with search and pagination
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Games list</returns>
        public IList<Game> GetAllGames(string filter, int pageSize, int pageIndex)
        {
            IList<Game> allGames = new List<Game>();
            var filterExpression = "filter[team][eq]=";
            string filterCondition = "";

            if (!string.IsNullOrEmpty(filter))
            {
                filterCondition = "&" + filterExpression + filter;
            }

            var request = new RestRequest("games/?key=" + Constants.API_KEY + "&sort=date_start&filter[season][eq]=" + Season + "&page[number]=" + pageIndex + "&page[size]=" + pageSize + filterCondition);
            string content = httpClient.Get(request).Content;
            GameAPIResponse response = JsonConvert.DeserializeObject<GameAPIResponse>(content);

            if (response != null)
            {
                allGames = response.Data;
            }

            return allGames;
        }

        /// <summary>
        /// Get details of a particular game
        /// </summary>
        /// <param name="gameId">Game Id</param>
        /// <returns>Game details</returns>
        public Game GetGameDetails(int gameId)
        {
            var request = new RestRequest("games/" + Season + "/game/" + gameId  + "?key=" + Constants.API_KEY);
            string content = httpClient.Get(request).Content;
            GameAPIResponse response = JsonConvert.DeserializeObject<GameAPIResponse>(content);
            Game allGames = response.Data.FirstOrDefault();
            return allGames;
        }

        /// <summary>
        /// Get top N upcomming games
        /// </summary>
        /// <param name="topNUmberFilter">Top N number</param>
        /// <returns>Games List</returns>
        public IList<Game> GetUpcommingGames(int topNUmberFilter)
        {
            IList<Game> allGames = new List<Game>();
            var request = new RestRequest("games/?sort=date_start&page[number]=1&filter[season][eq]=" + Season + "&page[size]=" + topNUmberFilter + "&key=" + Constants.API_KEY);
            string content = httpClient.Get(request).Content;
            GameAPIResponse response = JsonConvert.DeserializeObject<GameAPIResponse>(content);

            if (response != null)
            { 
                allGames = response.Data;
            }
            
            return allGames;
        }
    }
}
