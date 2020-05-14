using GamesZone.DependencyServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GamesZone
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            IDeviceOrientationService service = DependencyService.Get<IDeviceOrientationService>();
            DeviceOrientation orientation = service.GetDeviceOrientation();
        }
    }
}
