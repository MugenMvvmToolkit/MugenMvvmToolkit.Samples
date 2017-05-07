using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TabViewModel : MultiViewModel<ItemViewModel>
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;

        #endregion

        #region Constructors

        public TabViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            _messagePresenter = messagePresenter;
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
            itemViewModel.Name = "Dynamic tab";
            AddViewModel(itemViewModel);
            SelectedItem = itemViewModel;
        }

        private bool CanRemove(object o)
        {
            return SelectedItem != null;
        }

        private async void Remove(object o)
        {
            var item = SelectedItem;
            if (await _messagePresenter.ShowAsync($"Are you sure, you want to delete the view model {item.DisplayName}?", "Delete", MessageButton.YesNo) == MessageResult.Yes)
                RemoveViewModelAsync(item);
        }

        private bool CanInsert(object obj)
        {
            return SelectedItem != null;
        }

        private void Insert(object o)
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic tab";
            int selectedIndex = ItemsSource.IndexOf(SelectedItem);
            ItemsSource.Insert(selectedIndex, itemViewModel);
            SelectedItem = itemViewModel;
        }

        #endregion
    }
}