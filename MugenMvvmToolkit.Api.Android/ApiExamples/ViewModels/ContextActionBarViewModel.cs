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
        private string _contextText;
        private bool _contextActionBarVisible;

        #endregion

        #region Constructors

        public ContextActionBarViewModel(IToastPresenter toastPresenter)
        {
            _toastPresenter = toastPresenter;
            ExecuteCommand = new RelayCommand(Execute);
        }

        #endregion

        #region Commands

        public ICommand ExecuteCommand { get; private set; }

        private void Execute(object obj)
        {
            _toastPresenter.ShowAsync("Command was invoked", ToastDuration.Short);
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
    }
}