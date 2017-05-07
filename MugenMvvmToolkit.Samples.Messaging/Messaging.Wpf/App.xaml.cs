using System.Windows;
using Messaging.Portable;
using Messaging.Portable.Messages;
using Messaging.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Messaging.Wpf
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            new Bootstrapper<MainViewModel>(this, new MugenContainer());
        }

        #endregion

        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //By default EventAggregator uses the weak delegate to change this set the second parameter to false (ServiceProvider.EventAggregator.Subscribe<GlobalMessage>(HandleGlobalMessage, false)).
            ServiceProvider.EventAggregator.Subscribe<GlobalMessage>(HandleGlobalMessage);
        }

        #endregion

        #region Methods

        private void HandleGlobalMessage(object sender, GlobalMessage globalMessage)
        {
            Extensions.TraceMessage(this, sender, globalMessage);
            ServiceProvider.EventAggregator.Publish(this, new AppGlobalMessage());
        }

        #endregion
    }
}