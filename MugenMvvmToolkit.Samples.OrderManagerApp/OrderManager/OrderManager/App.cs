using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace OrderManager.XamForms
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