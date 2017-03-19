using Foundation;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Infrastructure;
using MugenMvvmToolkit.Infrastructure;
using UIKit;
using Validation.Portable;

namespace Validation.Touch
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