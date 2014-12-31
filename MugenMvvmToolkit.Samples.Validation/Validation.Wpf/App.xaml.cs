using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Validation.Portable.ViewModels;

namespace Validation.Wpf
{
    public partial class App : Application
    {
        public App()
        {
			new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }
    }
}