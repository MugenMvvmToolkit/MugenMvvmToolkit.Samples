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
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            _toastPresenter = toastPresenter;
            Command = new RelayCommand(Execute, CanExecute, this);
        }

        #endregion

        #region Properties

        #region Commands

        public ICommand Command { get; }

        #endregion

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
                $"The Command is invoked with cmdParameter: {cmdParameter ?? "null"}",
                ToastDuration.Long);
        }

        private bool CanExecute(object cmdParameter)
        {
            return CanExecuteCommand;
        }

        public void EventMethod(object eventParameter)
        {
            _toastPresenter.ShowAsync(
                $"The EventMethod is invoked with eventParameter: {eventParameter ?? "null"}",
                ToastDuration.Long);
        }

        public void EventMethodMultiParams(object param1, object param2)
        {
            _toastPresenter.ShowAsync(
                $"The EventMethodMultiParams is invoked with param1: {param1 ?? "null"}, param2: {param2 ?? "null"}", ToastDuration.Long);
        }

        #endregion
    }
}