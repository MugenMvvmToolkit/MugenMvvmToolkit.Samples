using System.Reflection;
using Windows.UI.Xaml.Controls;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.UWP.Infrastructure;
using Validation.Portable.ViewModels;

namespace Validation.UWP
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        #region Methods

        protected override UwpBootstrapperBase CreateBootstrapper(Frame frame)
        {
            return new Bootstrapper<Portable.App>(frame, new MugenContainer(), new[] {typeof(MainViewModel).GetTypeInfo().Assembly, GetType().GetTypeInfo().Assembly});
        }

        #endregion
    }
}