using Android.App;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Views.Activities;

namespace ApiExamples.Views
{
#if APPCOMPAT
    [Activity(Label = "ApiExamples.AppCompat", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true,
        Icon = "@drawable/icon", NoHistory = true)]
#else
    [Activity(Label = "ApiExamples", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true,
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