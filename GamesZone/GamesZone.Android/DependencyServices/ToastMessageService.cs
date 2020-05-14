using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GamesZone.DependencyServices;
using GamesZone.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageService))]
namespace GamesZone.Droid
{
    public class ToastMessageService : IToastMessageService
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}