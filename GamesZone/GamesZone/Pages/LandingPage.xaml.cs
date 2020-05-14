using GamesZone.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace GamesZone.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : Xamarin.Forms.TabbedPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height); //must be called
        //    IDeviceOrientationService service = DependencyService.Get<IDeviceOrientationService>();
        //    DeviceOrientation orientation = service.GetDeviceOrientation();
        //}
    }
}