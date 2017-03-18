using Android.App;
using Android.Content.PM;
using Android.OS;
using MugenMvvmToolkit.Xamarin.Forms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Binding.Droid
{
    [Activity(Label = "Binding", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new App(new PlatformBootstrapperService()));
        }
    }
}