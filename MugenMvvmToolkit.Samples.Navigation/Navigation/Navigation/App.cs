using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace Navigation
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