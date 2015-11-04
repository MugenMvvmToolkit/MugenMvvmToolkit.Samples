using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.WinRT;
using SplitView.WinRT.Infrastructure;
using SplitView.WinRT.Interfaces;

namespace SplitView.WinRT
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        #region Constructors

        static App()
        {
            //Reflection does not work at runtime using this code to handle back event.
            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                PlatformExtensions.SubscribeBackPressedEventDelegate = (o, action) =>
                {
                    var handler = ReflectionExtensions.CreateWeakEventHandler<object, BackPressedEventArgs>(o, action, (sender, h) => HardwareButtons.BackPressed -= h.Handle);
                    HardwareButtons.BackPressed += handler.Handle;
                };
                PlatformExtensions.SetBackPressedHandledDelegate = (o, b) => ((BackPressedEventArgs)o).Handled = b;
            }
            else
            {
                PlatformExtensions.SubscribeBackPressedEventDelegate = null;
                PlatformExtensions.SetBackPressedHandledDelegate = null;
            }
        }

        /// <summary>
        ///     Initializes the singleton application object.  This is the first line of authored code
        ///     executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Invoked when the application is launched normally by the end user.  Other entry points
        ///     will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            var content = Window.Current.Content as IFrameView;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (content == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                var bootstrapper = new SplitViewBootstrapper();
                await bootstrapper.InitializeAsync();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        // Something went wrong restoring state.
                        // Assume there is no state and continue
                    }
                }
                bootstrapper.Start();
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        ///     Invoked when application execution is being suspended.  Application state is saved
        ///     without knowing whether the application will be terminated or resumed with the contents
        ///     of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            SuspensionManager.SessionState[SplitViewBootstrapper.MainViewModelSuspensionKey] = ServiceProvider
                .ViewModelProvider
                .PreserveViewModel((IViewModel)ViewManager.GetDataContext(Window.Current.Content), null);
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        #endregion
    }
}