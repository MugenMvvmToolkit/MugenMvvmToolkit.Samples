using Windows.UI.Xaml.Controls;
using MugenMvvmToolkit;
using MugenMvvmToolkit.UWP.Infrastructure;

namespace SplitView.WinRT
{
    sealed partial class App
    {
        #region Methods

        protected override UwpBootstrapperBase CreateBootstrapper(Frame frame)
        {
            return new Bootstrapper<Portable.App>(frame, new MugenContainer());
        }

        #endregion
    }
}