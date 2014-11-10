using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class ModalViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;

        #endregion

        #region Constructors

        public ModalViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            NavigateCommand = new RelayCommand(Navigate);
        }

        #endregion

        #region Commands

        public ICommand NavigateCommand { get; private set; }

        private async void Navigate(object o)
        {
            using (var itemViewModel = GetViewModel<ItemViewModel>())
            {
                itemViewModel.Name = "Modal navigation item";
                await itemViewModel.ShowAsync();
            }
        }

        #endregion

        #region Overrides of CloseableViewModel

        protected override Task<bool> OnClosing(object parameter)
        {
            return _messagePresenter.ShowAsync("Close modal view model?", "Modal view model", MessageButton.YesNo)
                                    .ContinueWith(task => task.Result == MessageResult.Yes);
        }

        #endregion
    }
}