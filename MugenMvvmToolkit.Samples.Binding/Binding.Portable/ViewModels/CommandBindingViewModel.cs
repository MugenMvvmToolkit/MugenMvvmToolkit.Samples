using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class CommandBindingViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private bool _canExecuteCommand;

        #endregion

        #region Constructors

        public CommandBindingViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _toastPresenter = toastPresenter;
            Command = new RelayCommand(Execute, CanExecute, this);
        }

        #endregion

        #region Commands

        public ICommand Command { get; private set; }

        #endregion

        #region Properties

        public bool CanExecuteCommand
        {
            get { return _canExecuteCommand; }
            set
            {
                if (_canExecuteCommand == value)
                    return;
                _canExecuteCommand = value;
                OnPropertyChanged();                
            }
        }

        #endregion

        #region Methods

        private void Execute(object cmdParameter)
        {
            _toastPresenter.ShowAsync(
                string.Format("The Command is invoked with cmdParameter: {0}", cmdParameter ?? "null"),
                ToastDuration.Long);
        }

        private bool CanExecute(object cmdParameter)
        {
            return CanExecuteCommand;
        }

        public void EventMethod(object eventParameter)
        {
            _toastPresenter.ShowAsync(
                string.Format("The EventMethod is invoked with eventParameter: {0}", eventParameter ?? "null"),
                ToastDuration.Long);
        }

        public void EventMethodMultiParams(object param1, object param2)
        {
            _toastPresenter.ShowAsync(
                string.Format("The EventMethodMultiParams is invoked with param1: {0}, param2: {1}", param1 ?? "null",
                    param2 ?? "null"), ToastDuration.Long);
        }

        #endregion
    }
}