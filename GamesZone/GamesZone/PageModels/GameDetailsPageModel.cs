﻿using FreshMvvm;
using GamesZone.Models;
using GamesZone.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GamesZone.MVVM
{
    public class GameDetailsPageModel : FreshBasePageModel
    {
        public string Team1Info { get; set; }
        public string Team2Info { get; set; }
        public string MatchNumber { get; set; }
        public string MatchDateTime { get; set; }
        public string TicketsURL { get; set; }
        public string SeasonWeekGame { get; set; }
        public string Week { get; set; }
        public string Venue { get; set; }

        public string EventType { get; set; }

        private IGameService gameService;

        public override void Init(object initData)
        {
            if (initData != null)
            {
                int gameId = Convert.ToInt32(initData);
                GetGameDetails(gameId);
            }

            base.Init(initData);
        }

        public ICommand TapCommand
        {
            get
            {
                return new Command<string>(async (url) => await Launcher.OpenAsync(url));

            }
        }

        public GameDetailsPageModel(IGameService service)
        {
            gameService = service;
        }

        private void GetGameDetails(int gameId)
        {
            Game gameInfo = gameService.GetGameDetails(gameId);
            Team1Info = gameInfo.Team1.Nickname + " (" + gameInfo.Team1.Abbreviation + ")" + (gameInfo.Team1.IsAtHome ? " - Home" : " - Away");
            Team2Info = gameInfo.Team2.Nickname + " (" + gameInfo.Team2.Abbreviation + ")" + (gameInfo.Team2.IsAtHome ? " - Home" : " - Away");
            MatchNumber = gameInfo.GameNumber;
            Venue = gameInfo.Venue.Name;
            SeasonWeekGame = "Season " + gameInfo.Season + ", Week " + gameInfo.Week + " - Game " + gameInfo.GameNumber;
            TicketsURL = gameInfo.TicketsURL;
            EventType = gameInfo.EventType.Name;
            MatchDateTime = gameInfo.StartDate.LocalDateTime.ToString("ddd, dd MMM yyyy, HH:mm");
        }
    }
}
