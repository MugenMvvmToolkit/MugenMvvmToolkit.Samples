using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using OrderManager.Portable.ViewModels;
using Xamarin.Forms;

namespace OrderManager
{
    public class App : Application
    {
        public App()
        {
            XamarinFormsBootstrapperBase bootstrapper = XamarinFormsBootstrapperBase.Current ??
                                                        new Bootstrapper<MainViewModel>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }
    }
}