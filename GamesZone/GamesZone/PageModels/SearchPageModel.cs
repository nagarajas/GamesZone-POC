using FreshMvvm;
using GamesZone.Models;
using GamesZone.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamesZone.MVVM
{
    public class SearchPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private IGameService gameService;
        private ObservableCollection<GameInfoCard> searchResults;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SelectGameCommand { get; private set; }

        public SearchPageModel(IGameService service)
        {
            gameService = service;
            SelectGameCommand = new Command<GameInfoCard>(SelectGame);
        }
        public ICommand SearchGames => new Command<string>((string query) =>
        {
            SearchResults = GetSearchResults(query);
            CurrentPage.Title = "Search Results";
        });

        public ObservableCollection<GameInfoCard> SearchResults 
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                NotifyPropertyChanged();

            }
        }
     
        private ObservableCollection<GameInfoCard> GetSearchResults(string query)
        {
            IList<Game> gamesList = gameService.GetAllGames(query, 10, 1);
            ObservableCollection<GameInfoCard> cardList = new ObservableCollection<GameInfoCard>();


            foreach (Game game in gamesList)
            {
                GameInfoCard card = new GameInfoCard();
                card.GameNumber = "Game: " + game.GameNumber;
                card.TeamInfo = game.Team1.Nickname + " (" + game.Team1.Abbreviation + ")" + " Vs " + game.Team2.Nickname + " (" + game.Team2.Abbreviation + ")";
                card.MatchDateTime = game.StartDate.LocalDateTime.ToString("ddd, dd MMM yyyy, HH:mm");
                card.Venue = game.Venue.Name;
                card.TicketsURL = game.TicketsURL;
                card.GameId = game.GameId;
                cardList.Add(card);
            }

            return cardList;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        async void SelectGame(GameInfoCard g)
        {
            await CoreMethods.PushPageModel<GameDetailsPageModel>(g.GameId);
        }
    }
}
