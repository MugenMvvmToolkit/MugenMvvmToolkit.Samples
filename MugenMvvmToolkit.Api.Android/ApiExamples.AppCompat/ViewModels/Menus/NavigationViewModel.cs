using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels.Menus
{
    public class NavigationViewModel : ViewModelBase
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public NavigationViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            _toastPresenter = toastPresenter;
            ExecuteCommand = new RelayCommand<string>(Execute);
        }

        #endregion

        #region Commands

        public ICommand ExecuteCommand { get; private set; }

        private void Execute(string menuItem)
        {
            _toastPresenter.ShowAsync(menuItem, ToastDuration.Short);
        }

        #endregion
    }
}