using System.Windows.Input;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TabViewModel : MultiViewModel<ItemViewModel>
    {
        #region Constructors

        public TabViewModel()
        {
            AddCommand = new RelayCommand(Add);
            InsertCommand = new RelayCommand(Insert, CanInsert, this);
            RemoveCommand = new RelayCommand(Remove, CanRemove, this);
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; }

        public ICommand InsertCommand { get; }

        public ICommand RemoveCommand { get; }

        private void Add(object o)
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic item";
            AddViewModel(itemViewModel);
            SelectedItem = itemViewModel;
        }

        private bool CanRemove(object o)
        {
            return SelectedItem != null;
        }

        private void Remove(object o)
        {
            RemoveViewModelAsync(SelectedItem);
        }

        private bool CanInsert(object obj)
        {
            return SelectedItem != null;
        }

        private void Insert(object o)
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic tab";
            var selectedIndex = ItemsSource.IndexOf(SelectedItem);
            ItemsSource.Insert(selectedIndex, itemViewModel);
            SelectedItem = itemViewModel;
        }

        #endregion
    }
}