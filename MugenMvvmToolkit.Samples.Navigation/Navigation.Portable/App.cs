using System;
using System.Collections.Generic;
using System.Reflection;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models.Messages;
using Navigation.Portable.ViewModels;

namespace Navigation.Portable
{
    public class App : MvvmApplication
    {
        #region Properties

        public static bool IsBackground { get; private set; }

        #endregion

        #region Methods

        protected override void OnInitialize(IList<Assembly> assemblies)
        {
            base.OnInitialize(assemblies);

            //you can listen background\foreground messages in any place
            ServiceProvider.EventAggregator.Subscribe<ForegroundNavigationMessage>(OnForegroundMessage);
            ServiceProvider.EventAggregator.Subscribe<BackgroundNavigationMessage>(OnBackgroundMessage);
#if DEBUG
            Tracer.TraceInformation = true;
            Tracer.TraceWarning = true;
#endif
        }

        private static void OnBackgroundMessage(object arg1, BackgroundNavigationMessage message)
        {
            IsBackground = true;
            Tracer.Warn("App did enter background");
        }

        private static void OnForegroundMessage(object o, ForegroundNavigationMessage message)
        {
            IsBackground = false;
            Tracer.Warn("App did enter foreground");
        }

        public override Type GetStartViewModelType()
        {
            return typeof(MainViewModel);
        }

        #endregion
    }
}