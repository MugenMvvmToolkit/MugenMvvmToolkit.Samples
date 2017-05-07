using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.UWP.Infrastructure;

namespace Binding.UWP
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        #region Methods

        private static void Include()
        {
            IEnumerable<object> items = null;
            items?.Any();
            items?.FirstOrDefault();
        }

        protected override UwpBootstrapperBase CreateBootstrapper(Frame frame)
        {
            Include();
            return new Bootstrapper<Portable.App>(frame, new MugenContainer(), new[]
            {
                typeof(App).GetTypeInfo().Assembly,
                typeof(MainViewModel).GetTypeInfo().Assembly
            });
        }

        #endregion
    }
}