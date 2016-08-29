using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace Validation
{
    public class App : Application
    {
        public App(XamarinFormsBootstrapperBase.IPlatformService platformService)
        {
            XamarinFormsBootstrapperBase bootstrapper = XamarinFormsBootstrapperBase.Current ??
                                                        new Bootstrapper<Portable.App>(platformService, new AutofacContainer());
            bootstrapper.Start();
        }
    }
}