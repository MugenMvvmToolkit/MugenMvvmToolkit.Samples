using System.Windows.Input;
using Messaging.Portable.Messages;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Messaging.Portable.ViewModels
{
    public class ViewMessageViewModel : CloseableViewModel, IHandler<ViewMessage>
    {
        #region Constructors

        public ViewMessageViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        #endregion

        #region Implementation of interfaces

        public void Handle(object sender, ViewMessage message)
        {
            Extensions.TraceMessage(this, sender, message);
        }

        #endregion

        #region Commands

        public ICommand SendMessageCommand { get; }

        private void SendMessage()
        {
            Publish(new ViewModelMessage());
        }

        #endregion
    }
}