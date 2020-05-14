﻿using FreshMvvm;
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
    public class PlayersListPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private ObservableCollection<PlayerImageCard> playersList;
        private IPlayerService playerService;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand PlayerTappedCommand { get; set; }
        public ICommand SearchTextChangedCommand { get; set; }

        public PlayerImageCard SelectedPlayer { get; set; }

        private bool isBusy;

        public bool IsBusy 
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                NotifyPropertyChanged("IsBusy");
            }
        }

        public PlayersListPageModel(IPlayerService service)
        {
            playerService = service;
            PlayerTappedCommand = new Command(SelectPlayer);
            SearchTextChangedCommand = new Command<string>(SearchTextChanged);
        }

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

        private ObservableCollection<PlayerImageCard> GetPlayerCardsList(string filter)
        {
            IList<Player> players = playerService.GetAllPlayers(filter, 10, 1);
            ObservableCollection<PlayerImageCard> cardList = new ObservableCollection<PlayerImageCard>();

            foreach(Player p in players)
            {
                PlayerImageCard card = new PlayerImageCard();
                card.ImageURL = (p.ImageURL != null && p.ImageURL != "") ? p.ImageURL : "defaultuser.png";
                card.FullName = p.FirstName + " " + p.LastName;
                card.PlayerId = p.CentralId;
                cardList.Add(card);
            }

            return cardList;
        }

        public ICommand SearchPlayers => new Command<string>((string query) =>
        {
            PlayersList = GetPlayerCardsList(query);
            CurrentPage.Title = "Search Results";
        });

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

        async void SelectPlayer()
        {
            await CoreMethods.PushPageModel<PlayerDetailsPageModel>(SelectedPlayer.PlayerId);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<PlayerImageCard> SearchPlayer(string filter)
        {
            IEnumerable<PlayerImageCard> obsCollection = (IEnumerable<PlayerImageCard>) PlayersList;
            List<PlayerImageCard> list = new List<PlayerImageCard>(obsCollection);
            list = list.FindAll(m => m.FullName.Contains(filter)).ToList();
            return new ObservableCollection<PlayerImageCard>(list);
        }

        void SearchTextChanged(string newText)
        {
            IsBusy = true;
            PlayersList = GetPlayerCardsList(newText);
            IsBusy = false;
        }
    }
}
