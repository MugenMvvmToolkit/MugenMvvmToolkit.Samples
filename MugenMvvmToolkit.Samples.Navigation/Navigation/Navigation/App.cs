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
            XamarinFormsBootstrapperBase bootstrapper = XamarinFormsBootstrapperBase.Current ??
                                                        new Bootstrapper<MainViewModel>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }
    }
}