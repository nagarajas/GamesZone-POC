using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content.Res;
using Android.Views;
using Android.Widget;
using GamesZone.CustomControls;
using GamesZone.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedCornerSearchBar), typeof(RoundedCornerSearchBarRenderer))]
namespace GamesZone.Droid
{
    public class RoundedCornerSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.roundedcorner_searchbar_style, null));
            }
        }
    }
}