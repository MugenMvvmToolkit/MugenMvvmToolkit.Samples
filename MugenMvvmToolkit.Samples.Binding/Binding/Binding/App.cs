using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Xamarin.Forms;

namespace Binding
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