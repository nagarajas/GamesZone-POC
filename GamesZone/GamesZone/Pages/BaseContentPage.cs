using GamesZone.DependencyServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GamesZone.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            DeviceOrientation orientation = DependencyService.Get<IDeviceOrientationService>().GetDeviceOrientation();

            if (orientation == DeviceOrientation.Landscape)
            { 
                DependencyService.Get<IToastMessageService>().Show("We don't support landscape mode");
            }
        }
    }
}
