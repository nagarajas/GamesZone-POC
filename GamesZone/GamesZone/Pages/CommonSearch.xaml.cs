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
    public partial class CommonSearch : ContentView
    {
        public bool IsGamesSearch
        {
            get; set;
        }

        public bool IsPlayerSearch
        {
            get; set;
        }

        public CommonSearch()
        {
            InitializeComponent();
        }
    }
}