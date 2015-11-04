using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class SnackbarViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public SnackbarViewModel(IToastPresenter toastPresenter, IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(toastPresenter, "toastPresenter");
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _toastPresenter = toastPresenter;
            _messagePresenter = messagePresenter;
            ShowSnackbarCommand = new RelayCommand(ShowSnackbar);
            ShowSnackbarActionCommand = new RelayCommand(ShowSnackbarAction);
        }

        #endregion

        #region Commands

        public ICommand ShowSnackbarCommand { get; private set; }

        public ICommand ShowSnackbarActionCommand { get; private set; }

        private void ShowSnackbar()
        {
            _toastPresenter.ShowAsync("Simple message", ToastDuration.Long);
        }

        public void ShowSnackbarAction()
        {
            _toastPresenter.ShowAsync(new Message {ActionTitle = "Command action", Text = "Message with action", Command = new RelayCommand(Execute)},
                ToastDuration.Long);
        }

        private void Execute()
        {
            _messagePresenter.ShowAsync("Item clicked");
        }

        #endregion
    }
}