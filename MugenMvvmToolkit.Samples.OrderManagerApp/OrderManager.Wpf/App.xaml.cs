using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }
    }
}