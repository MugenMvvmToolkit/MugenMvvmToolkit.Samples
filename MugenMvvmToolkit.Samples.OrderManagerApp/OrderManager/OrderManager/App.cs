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
            var bootstrapper = new Bootstrapper<MainViewModel>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }
    }
}