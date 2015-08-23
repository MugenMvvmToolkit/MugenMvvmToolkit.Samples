using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.Interfaces;

namespace OrderManager.Portable.ViewModels
{
    public class EditorWrapperViewModel<T> : WrapperViewModelBase<T>, IEditorWrapperViewModel
        where T : class, IEditableViewModel
    {
        #region Fields

        private ICommand _applyCommand;

        #endregion

        #region Constructors

        public EditorWrapperViewModel()
        {
            ApplyCommand = RelayCommandBase.FromAsyncHandler<object>(Apply, CanApply, false, this);
        }

        #endregion

        #region Implementation of IEditableWindowViewModel

        public ICommand ApplyCommand
        {
            get { return _applyCommand; }
            set
            {
                if (Equals(value, _applyCommand)) return;
                _applyCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command's methosd

        private Task Apply(object obj)
        {
            OperationResult = true;
            return CloseAsync(obj).WithBusyIndicator(this);
        }

        private bool CanApply(object obj)
        {
            return ViewModel != null && ViewModel.HasChanges && ViewModel.IsValid;
        }

        #endregion

        #region Overrides of WrapperViewModelBase<T>

        protected override void OnClosed(object parameter)
        {
            if (!OperationResult.GetValueOrDefault() && ViewModel != null && ViewModel.IsEntityInitialized)
                ViewModel.CancelChanges();
        }

        #endregion
    }
}