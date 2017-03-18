using System.Reflection;
using Windows.UI.Xaml.Controls;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.UWP.Infrastructure;

namespace Binding.UWP
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        #region Methods

        protected override UwpBootstrapperBase CreateBootstrapper(Frame frame)
        {
            return new Bootstrapper<Portable.App>(frame, new MugenContainer(), new[]
            {
                typeof(App).GetTypeInfo().Assembly,
                typeof(MainViewModel).GetTypeInfo().Assembly
            });
        }

        #endregion
    }
}