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
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            _toastPresenter = toastPresenter;
            _messagePresenter = messagePresenter;
            ShowToastCommand = new RelayCommand(ShowToast);
            ShowSnackbarCommand = new RelayCommand(ShowSnackbar);
            ShowSnackbarActionCommand = new RelayCommand(ShowSnackbarAction);
        }

        #endregion

        #region Commands

        public ICommand ShowToastCommand { get; }

        public ICommand ShowSnackbarCommand { get; }

        public ICommand ShowSnackbarActionCommand { get; }

        private void ShowToast()
        {
            _toastPresenter.ShowAsync("Simple message", ToastDuration.Long);
        }

        private void ShowSnackbar()
        {
            _toastPresenter.ShowAsync(new Message {Text = "Simple message"}, ToastDuration.Long);
        }

        private void ShowSnackbarAction()
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