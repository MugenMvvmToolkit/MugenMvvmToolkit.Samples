using System.Windows;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;

namespace Binding.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }
    }
}