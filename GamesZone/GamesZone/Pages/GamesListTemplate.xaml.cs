using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesZone.MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesListTemplate : ContentView
    {
        public GamesListTemplate()
        {
            InitializeComponent();
        }
    }
}