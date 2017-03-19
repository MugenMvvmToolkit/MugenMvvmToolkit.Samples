using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using SplitView.Portable.Models;

namespace SplitView.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHasState
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private IViewModel _selectedItem;

        private static readonly DataConstant<IDataContext> SelectedItemState = DataConstant.Create(() => SelectedItemState, true);

        #endregion

        #region Constructors

        public MainViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            _toastPresenter = toastPresenter;
            var items = new List<MenuItemModel>();
            for (var i = 0; i < 10; i++)
            {
                var item = new MenuItemModel
                {
                    Id = i,
                    Name = "Item " + i
                };
                items.Add(item);
            }
            Items = items;
            OpenItemCommand = new RelayCommand<MenuItemModel>(OpenItem);
        }

        #endregion

        #region Properties

        public IViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public IList<MenuItemModel> Items { get; private set; }

        #endregion

        #region Commands

        public ICommand OpenItemCommand { get; private set; }

        private async void OpenItem(MenuItemModel item)
        {
            if (item == null)
                return;
            using (var vm = GetViewModel<ItemViewModel>())
            {
                vm.DisplayName = item.Name;
                vm.Id = item.Id;
                await vm.ShowAsync();
                _toastPresenter.ShowAsync(vm.DisplayName + " was closed", ToastDuration.Short);
            }
        }

        public void LoadState(IDataContext state)
        {
            var context = state.GetData(SelectedItemState);
            if (context != null)
                SelectedItem = ViewModelProvider.RestoreViewModel(context, null, true);
        }

        public void SaveState(IDataContext state)
        {
            var selectedItem = SelectedItem;
            if (selectedItem != null)
                state.AddOrUpdate(SelectedItemState, ViewModelProvider.PreserveViewModel(selectedItem, null));
        }

        #endregion
    }
}