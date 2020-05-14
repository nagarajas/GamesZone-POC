using FreshMvvm;
using GamesZone.Models;
using GamesZone.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamesZone.MVVM
{
    public class PlayerDetailsPageModel : FreshBasePageModel
    {
        #region Private variables
        private IPlayerService playerService; 
        #endregion

        #region Properties
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string RookieYear { get; set; }
        public string IsForeignPlayer { get; set; }
        public string ImageURL { get; set; }
        public string SchoolName { get; set; }
        public string Position { get; set; }
        #endregion

        #region Lifecycle methods
        public override void Init(object initData)
        {
            if (initData != null)
            {
                int playerId = Convert.ToInt32(initData);
                GetPlayerDetails(playerId);
            }

            base.Init(initData);
        }
        #endregion

        #region Constructor
        public PlayerDetailsPageModel(IPlayerService service)
        {
            playerService = service;
        } 
        #endregion

        #region Private methods
        private void GetPlayerDetails(int playerId)
        {
            Player playerInfo = playerService.GetPlayerDetails(playerId);
            FullName = playerInfo.FirstName + (!string.IsNullOrEmpty(playerInfo.MiddleName) ? " " + playerInfo.MiddleName : "") + " " + playerInfo.LastName;
            BirthDate = playerInfo.BirthDate;
            BirthPlace = playerInfo.BirthPlace;
            Height = playerInfo.Height.ToString();
            Weight = playerInfo.Weight.ToString();
            RookieYear = playerInfo.RookieYear.ToString();
            SchoolName = playerInfo.School.Name;
            IsForeignPlayer = playerInfo.ForeignPlayer ? "Yes" : "No";
            ImageURL = (playerInfo.ImageURL != null && playerInfo.ImageURL != "") ? playerInfo.ImageURL : "defaultuser.png";
            Position = playerInfo.Position.Description;
        } 
        #endregion
    }
}
