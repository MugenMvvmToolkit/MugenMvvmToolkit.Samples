using System.Windows.Input;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels.Fragments
{
    public class BackStackFragmetViewModel : CloseableViewModel
    {
        #region Fields

        private IViewModel _viewModel;

        #endregion

        #region Constructors

        public BackStackFragmetViewModel()
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove, CanRemove, this);
        }

        #endregion

        #region Properties

        public IViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (Equals(_viewModel, value))
                    return;
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        private void Add()
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Content view model";
            ViewModel = itemViewModel;
        }

        private bool CanRemove(object obj)
        {
            return ViewModel != null && CloseCommand.CanExecute(obj);
        }

        private void Remove(object o)
        {
            CloseCommand.Execute(o);
        }

        #endregion
    }
}