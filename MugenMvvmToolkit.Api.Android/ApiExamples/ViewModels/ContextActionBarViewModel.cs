using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class ContextActionBarViewModel : ViewModelBase
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private bool _contextActionBarVisible;
        private string _contextText;

        #endregion

        #region Constructors

        public ContextActionBarViewModel(IToastPresenter toastPresenter)
        {
            _toastPresenter = toastPresenter;
            ExecuteCommand = new RelayCommand(Execute);
        }

        #endregion

        #region Properties

        public bool ContextActionBarVisible
        {
            get { return _contextActionBarVisible; }
            set
            {
                if (value == _contextActionBarVisible)
                    return;
                _contextActionBarVisible = value;
                OnPropertyChanged();
            }
        }

        public string ContextText
        {
            get { return _contextText; }
            set
            {
                if (Equals(value, _contextText))
                    return;
                _contextText = value;
                OnPropertyChanged();
                _toastPresenter.ShowAsync(value, ToastDuration.Short);
            }
        }

        #endregion

        #region Commands

        public ICommand ExecuteCommand { get; }

        private void Execute()
        {
            _toastPresenter.ShowAsync("Command was invoked", ToastDuration.Short);
        }

        #endregion
    }
}