using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Navigation.Portable.ViewModels;

namespace Navigation.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }
    }
}