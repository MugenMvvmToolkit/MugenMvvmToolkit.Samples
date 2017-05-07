using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MugenMvvmToolkit.Xamarin.Forms.Android;

namespace Validation.Droid
{
    [Activity(Label = "Validation", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new App(new PlatformBootstrapperService(() => Forms.Context)));
        }
    }
}