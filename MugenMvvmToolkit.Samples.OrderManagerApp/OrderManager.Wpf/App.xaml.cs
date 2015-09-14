using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace OrderManager.Wpf
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            new Bootstrapper<Portable.App>(this, new AutofacContainer());
        }

        #endregion
    }
}