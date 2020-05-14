using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace GamesZone.Navigation
{
    public class FreshBottomTabbedNavigationContainer : FreshTabbedNavigationContainer
    {
        public FreshBottomTabbedNavigationContainer()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
