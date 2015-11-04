using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.WinRT.Infrastructure;
using SplitView.WinRT.Interfaces;

namespace SplitView.WinRT.Infrastructure
{
    public class SplitViewBootstrapper : Bootstrapper<Portable.App>
    {
        #region Fields

        public const string MainViewModelSuspensionKey = "mainVm";

        #endregion

        #region Constructors

        public SplitViewBootstrapper(IEnumerable<Assembly> assemblies = null,
            IViewModelSettings viewModelSettings = null,
            PlatformInfo platform = null)
            : base(new Frame(), new AutofacContainer(), assemblies, viewModelSettings, platform)
        {
        }

        #endregion

        #region Methods

        protected override void InitializeInternal()
        {
            base.InitializeInternal();
            //Associate the frame with a SuspensionManager key                                
            SuspensionManager.RegisterFrame(RootFrame, "AppFrame");
            RootFrame.NavigationFailed += OnNavigationFailed;
        }

        public override void Start()
        {
            var current = MvvmApplication.Current;
            var ctx = new DataContext(current.Context);

            object value;
            IViewModel viewModel;
            if (SuspensionManager.SessionState.TryGetValue(MainViewModelSuspensionKey, out value))
            {
                viewModel = current.IocContainer
                    .Get<IViewModelProvider>()
                    .RestoreViewModel((IDataContext)value, ctx, true);
            }
            else
            {
                var startViewModelType = current.GetStartViewModelType();
                viewModel = current.IocContainer
                    .Get<IViewModelProvider>()
                    .GetViewModel(startViewModelType, ctx);
            }

            var view = (IFrameView)ViewManager.GetOrCreateView(viewModel, context: ctx);
            view.ContentFrame = RootFrame;
            Window.Current.Content = (UIElement)view;
        }

        /// <summary>
        ///     Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        #endregion
    }
}