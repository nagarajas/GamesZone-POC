using GamesZone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Services
{
    public interface IGameService
    {
        /// <summary>
        /// Game Season
        /// </summary>
        int Season { get; }
        
        /// <summary>
        /// Get top N upcomming games
        /// </summary>
        /// <param name="topNUmberFilter">Top N number</param>
        /// <returns>Games List</returns>
        IList<Game> GetUpcommingGames(int topNUmberFilter);

        /// <summary>
        /// Get all games with search and pagination
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <returns>Games list</returns>
        IList<Game> GetAllGames(string filter, int pageSize, int pageIndex);

        /// <summary>
        /// Get details of a particular game
        /// </summary>
        /// <param name="gameId">Game Id</param>
        /// <returns>Game details</returns>
        Game GetGameDetails(int gameId);
    }
}
