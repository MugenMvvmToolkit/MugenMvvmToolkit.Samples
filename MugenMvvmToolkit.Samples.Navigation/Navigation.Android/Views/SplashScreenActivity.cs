using Android.App;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Views.Activities;

namespace Navigation.Android.Views
{
#if APPCOMPAT
    [Activity(Label = "Navigation.Android.AppCompat", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true,
        Icon = "@drawable/icon", NoHistory = true)]
#else
    [Activity(Label = "Navigation.Android", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true,
        Icon = "@drawable/icon", NoHistory = true)]
#endif
    public class SplashScreenActivity : SplashScreenActivityBase
    {
        #region Overrides of SplashScreenActivityBase

        protected override AndroidBootstrapperBase CreateBootstrapper()
        {
            return new Setup();
        }

        #endregion
    }
}