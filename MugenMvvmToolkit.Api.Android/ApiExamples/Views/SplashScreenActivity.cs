using Android.App;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit.Android.Views.Activities;

namespace ApiExamples.Views
{
#if APPCOMPAT
    [Activity(Label = "ApiExamples.AppCompat", Theme = "@style/Theme.AppCompat.NoActionBar.FullScreen", MainLauncher = true,
        Icon = "@drawable/icon", NoHistory = true)]
#else
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat.NoActionBar.FullScreen", MainLauncher = true,
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