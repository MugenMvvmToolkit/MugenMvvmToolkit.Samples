using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Navigation.Portable.ViewModels;
using Xamarin.Forms;

namespace Navigation
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