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
    public partial class GameDetailsPage : BaseContentPage
    {
        public GameDetailsPage()
        {
            InitializeComponent();
            
        }
    }
}