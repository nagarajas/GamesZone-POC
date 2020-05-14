using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesZone.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonSearch : ContentView
    {
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(CommonSearch), string.Empty);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(CommonSearch), null);
        public static readonly BindableProperty SearchTextChangedCommandProperty = BindableProperty.Create(nameof(SearchTextChangedCommand), typeof(ICommand), typeof(CommonSearch), null);

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set {SetValue(PlaceholderTextProperty, value); }
        }

        public ICommand SearchTextChangedCommand
        {
            get { return (ICommand)GetValue(SearchTextChangedCommandProperty); }
            set { 
                SetValue(SearchTextChangedCommandProperty, value); }
        }

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }

        public CommonSearch()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}