using GamesZone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Services
{
    public interface IPlayerService
    {
        /// <summary>
        /// Gets the list of players with search and pagination
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Players list</returns>
        IList<Player> GetAllPlayers(string filter, int pageSize, int pageIndex);

        /// <summary>
        /// Get details of a particular player
        /// </summary>
        /// <param name="playerId">Player Id</param>
        /// <returns>Player details</returns>
        Player GetPlayerDetails(int playerId);
    }
}
