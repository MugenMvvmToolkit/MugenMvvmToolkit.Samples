using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Infrastructure;
using Navigation.Portable;
using UIKit;

namespace Navigation.Touch
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvvmAppDelegateBase
    {
        #region Methods

        protected override TouchBootstrapperBase CreateBootstrapper(UIWindow window)
        {
            return new Bootstrapper<App>(window, new MugenContainer());
        }

        #endregion
    }
}