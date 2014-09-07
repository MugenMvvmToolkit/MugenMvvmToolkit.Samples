//NOTE you can replace standard App.xaml.cs by this file;
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
			//NOTE Remove tag StartupUri from App.xaml
            new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }
    }
}