using System.Windows.Input;
using Messaging.Portable.Messages;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Messaging.Portable.ViewModels
{
    public class RightViewModel : ViewModelBase, IHandler<ViewModelMessage>
    {
        #region Constructors

        public RightViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        #endregion

        #region Implementation of interfaces

        public void Handle(object sender, ViewModelMessage message)
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