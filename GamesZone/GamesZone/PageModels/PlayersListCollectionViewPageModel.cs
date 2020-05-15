using FreshMvvm;
using GamesZone.Models;
using GamesZone.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamesZone.MVVM
{
    public class PlayersListCollectionViewPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        #region Private variables
        private ObservableCollection<PlayerImageCard> playersList;
        private IPlayerService playerService;
        private string searchFilterText;
        #endregion

        #region Event delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ICommand PlayerSelectionChangedCommand { get; set; }
        public string SearchFilterText
        {
            get
            {
                return searchFilterText;
            }
            set
            {
                searchFilterText = value;
                PlayersList = GetPlayerCardsList(searchFilterText);
            }
        }
        public ICommand SearchPlayersCommand { get; set; }

        public PlayerImageCard SelectedPlayer { get; set; }
        public ObservableCollection<PlayerImageCard> PlayersList
        {
            get
            {
                return playersList;
            }
            set
            {
                playersList = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public PlayersListCollectionViewPageModel(IPlayerService service)
        {
            playerService = service;
            PlayerSelectionChangedCommand = new Command(SelectPlayer);
            SearchPlayersCommand = new Command<string>(SearchPlayers);
        }
        #endregion

        #region Lifecycle methods
        public async override void Init(object initData)
        {
            try
            {

                PlayersList = GetPlayerCardsList("");
                base.Init(initData);

            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", "An error has occured", "OK");
            }
        }
        #endregion

        #region Event Handlers
        async void SelectPlayer()
        {
            await CoreMethods.PushPageModel<PlayerDetailsPageModel>(SelectedPlayer.PlayerId);
        }

        void SearchPlayers(string query)
        {
            PlayersList = GetPlayerCardsList(query);
            CurrentPage.Title = "Search Results";
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Private methods
        private ObservableCollection<PlayerImageCard> GetPlayerCardsList(string filter)
        {
            IList<Player> players = playerService.GetAllPlayers(filter, 10, 1);
            ObservableCollection<PlayerImageCard> cardList = new ObservableCollection<PlayerImageCard>();

            foreach (Player p in players)
            {
                PlayerImageCard card = new PlayerImageCard();
                card.ImageURL = (p.ImageURL != null && p.ImageURL != "") ? p.ImageURL : "defaultuser.png";
                card.FullName = p.FirstName + " " + p.LastName;
                card.PlayerId = p.CentralId;
                cardList.Add(card);
            }

            return cardList;
        }

        private ObservableCollection<PlayerImageCard> SearchPlayer(string filter)
        {
            IEnumerable<PlayerImageCard> obsCollection = (IEnumerable<PlayerImageCard>)PlayersList;
            List<PlayerImageCard> list = new List<PlayerImageCard>(obsCollection);
            list = list.FindAll(m => m.FullName.Contains(filter)).ToList();
            return new ObservableCollection<PlayerImageCard>(list);
        }
        #endregion
    }
}
