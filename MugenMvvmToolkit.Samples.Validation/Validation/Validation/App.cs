using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Validation.Portable.ViewModels;
using Xamarin.Forms;

namespace Validation
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