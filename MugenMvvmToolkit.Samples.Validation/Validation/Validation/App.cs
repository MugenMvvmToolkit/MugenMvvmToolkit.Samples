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
            XamarinFormsBootstrapperBase bootstrapper = XamarinFormsBootstrapperBase.Current ??
                                                        new Bootstrapper<MainViewModel>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }
    }
}