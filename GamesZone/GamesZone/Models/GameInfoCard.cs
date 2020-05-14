using FreshMvvm;
using GamesZone.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GamesZone.Models
{
    public class GameInfoCard : FreshBasePageModel
    {
        public int GameId { get; set; }
        public string GameNumber { get; set; }
        public string TeamInfo { get; set; }
        public string Venue { get; set; }
        public string MatchDateTime { get; set; }
        public string TicketsURL { get; set; }

        public ICommand TapCommand
        {
            get
            {
                return new Command<string>(async (url) => await Launcher.OpenAsync(url));

            }
        }
    }
}
