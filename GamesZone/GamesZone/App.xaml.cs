using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GamesZone.Services;
using GamesZone.Pages;
using FreshMvvm;
using GamesZone.MVVM;
using GamesZone.Navigation;

namespace GamesZone
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RegisterDependencies();
            SetMainPage();
        }

        private void SetMainPage()
        {
            var tabbedNavigation = new FreshBottomTabbedNavigationContainer();
            tabbedNavigation.AddTab<UpcommingGamesPageModel>("Upcomming_Games", null);
            tabbedNavigation.AddTab<PlayersListPageModel>("PlayersList_FL", null);
            tabbedNavigation.AddTab<PlayersListCollectionViewPageModel>("PlayersList_CV", null);
            MainPage = tabbedNavigation;
        }

        private void RegisterDependencies()
        {
            FreshIOC.Container.Register<IGameService, GameService>();
            FreshIOC.Container.Register<IPlayerService, PlayerService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
