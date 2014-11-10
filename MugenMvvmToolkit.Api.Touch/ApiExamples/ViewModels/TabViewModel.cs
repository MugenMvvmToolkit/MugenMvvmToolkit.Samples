using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TabViewModel : MultiViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;

        #endregion

        #region Constructors

        public TabViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            AddCommand = new RelayCommand(Add);
            InsertCommand = new RelayCommand(Insert, CanInsert, this);
            RemoveCommand = new RelayCommand(Remove, CanRemove, this);
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; private set; }

        public ICommand InsertCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

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
            if (await _messagePresenter.ShowAsync("Delete view model?", "Delete", MessageButton.YesNo) == MessageResult.Yes)
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