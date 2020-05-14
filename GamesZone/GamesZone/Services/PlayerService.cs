using GamesZone.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesZone.Services
{
    public class PlayerService : IPlayerService
    {
        RestClient httpClient;
        public PlayerService()
        {
            httpClient = new RestClient(Constants.API_BASE_URL);
        }

        /// <summary>
        /// Gets the list of players with search and pagination
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Players list</returns>
        public IList<Player> GetAllPlayers(string filter, int pageSize, int pageIndex)
        {
            IList<Player> allPlayers = new List<Player>();
            var filterExpression = "";

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filterExpression = "&filter[first_name][eq] =" + filter;
            }

            var request = new RestRequest("players/?key=" + Constants.API_KEY + "&sort=date_start&page[number]=" + pageIndex + "&page[size]=" + pageSize + filterExpression);
            string content = httpClient.Get(request).Content;
            PlayerAPIResponse response = JsonConvert.DeserializeObject<PlayerAPIResponse>(content);

            if (response != null)
            {
                allPlayers = response.Data;
            }

            return allPlayers; 
        }

        /// <summary>
        /// Get details of a particular player
        /// </summary>
        /// <param name="playerId">Player Id</param>
        /// <returns>Player details</returns>
        public Player GetPlayerDetails(int playerId)
        {
            Player playerInfo = new Player();
            var request = new RestRequest("players/" + playerId + "/? key=" + Constants.API_KEY);
            string content = httpClient.Get(request).Content;
            PlayerAPIResponse response = JsonConvert.DeserializeObject<PlayerAPIResponse>(content);

            if (response != null)
            {
                playerInfo = response.Data.FirstOrDefault();
            }

            return playerInfo;
        }
    }
}
