﻿using GamesZone.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesZone.MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersListPage : BaseContentPage
    {
        public PlayersListPage()
        {
            InitializeComponent();
        }

        private void searchControl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}