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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GamesZone.MVVM
{
    public class UpcommingGamesPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        #region Private variables
        private IGameService gameService;
        private ObservableCollection<GameInfoCard> upcommingGames;
        #endregion

        #region Event delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<GameInfoCard> UpcommingGames
        {
            get
            {
                return upcommingGames;
            }
            set
            {
                upcommingGames = value;
                NotifyPropertyChanged();

            }
        }
        public ICommand SelectGameCommand { get; private set; }
        public ICommand SearchTextChangedCommand { get; set; }

        public ICommand SearchGamesCommand { get; set; }
        #endregion

        #region Constructor
        public UpcommingGamesPageModel(IGameService service, IPlayerService ps)
        {
            gameService = service;
            SelectGameCommand = new Command<GameInfoCard>(SelectGame);
            SearchTextChangedCommand = new Command<string>(SearchTextChanged);
            SearchGamesCommand = new Command<string>(SearchGames);
        }
        #endregion

        #region Lifecycle methods
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        public async override void Init(object initData)
        {
            try
            {

                UpcommingGames = GetUpcommingGamesListData();
                base.Init(initData);

            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", "An error has occured", "OK");
            }
        }
        #endregion

        #region Event handlers
        void SearchGames(string query)
        {
            UpcommingGames = GetSearchResults(query);
        }

        async void SearchTextChanged(string newText)
        {
            UpcommingGames = GetSearchResults(newText);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        async void SelectGame(GameInfoCard g)
        {
            await CoreMethods.PushPageModel<GameDetailsPageModel>(g.GameId);
        }
        #endregion

        #region Private methods
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

        private ObservableCollection<GameInfoCard> GetUpcommingGamesListData()
        {
            IList<Game> gamesList = gameService.GetUpcommingGames(20);
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
        #endregion
    }
}
