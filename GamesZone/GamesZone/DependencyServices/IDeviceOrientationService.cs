using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace GamesZone.DependencyServices
{
    public interface IDeviceOrientationService
    {
        DeviceOrientation GetDeviceOrientation();
    }
}
