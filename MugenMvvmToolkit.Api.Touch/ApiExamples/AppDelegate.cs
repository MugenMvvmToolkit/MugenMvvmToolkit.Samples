using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Infrastructure;
using UIKit;

namespace ApiExamples
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvvmAppDelegateBase
    {
        #region Constructors

        static AppDelegate()
        {
#if DEBUG
            Tracer.TraceInformation = true;
            Tracer.TraceWarning = true;
#endif
        }

        #endregion

        #region Methods

        protected override TouchBootstrapperBase CreateBootstrapper(UIWindow window)
        {
            return new Bootstrapper<MainViewModel>(window, new MugenContainer());
        }

        #endregion
    }
}