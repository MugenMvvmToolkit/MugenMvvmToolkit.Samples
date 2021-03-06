using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Validation.Wpf
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            new Bootstrapper<Portable.App>(this, new MugenContainer());
        }

        #endregion
    }
}