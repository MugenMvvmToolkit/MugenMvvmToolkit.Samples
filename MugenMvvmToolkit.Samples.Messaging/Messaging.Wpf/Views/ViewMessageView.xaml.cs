using System.Windows;
using Messaging.Portable;
using Messaging.Portable.Messages;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Interfaces.Views;

namespace Messaging.Wpf.Views
{
    //Using the IViewModelAwareView interface to get access to the ViewModel.
    public partial class ViewMessageView : IViewModelAwareView<IViewModel>, IHandler<ViewModelMessage>
    {
        #region Constructors

        public ViewMessageView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            //Sending message to the ViewModel
            ViewModel.Publish(this, new ViewMessage());
        }

        #endregion

        #region Implementation of IViewModelAwareView<IViewModel>

        public IViewModel ViewModel { get; set; }

        #endregion

        #region Implementation of IHandler<in ViewMessage>

        public void Handle(object sender, ViewModelMessage message)
        {
            Extensions.TraceMessage(this, sender, message);
        }

        #endregion
    }
}