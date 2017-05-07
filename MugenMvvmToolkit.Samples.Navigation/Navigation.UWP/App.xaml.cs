using Windows.UI.Xaml.Controls;
using MugenMvvmToolkit;
using MugenMvvmToolkit.UWP.Infrastructure;

namespace Navigation.UWP
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        #region Constructors

        /// <summary>
        ///     Initializes the singleton application object.  This is the first line of authored code
        ///     executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        protected override UwpBootstrapperBase CreateBootstrapper(Frame frame)
        {
            return new Bootstrapper<Portable.App>(frame, new MugenContainer());
        }

        #endregion
    }
}