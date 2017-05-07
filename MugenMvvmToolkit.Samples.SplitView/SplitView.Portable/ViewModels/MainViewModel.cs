using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using SplitView.Portable.Models;

namespace SplitView.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private IViewModel _selectedItem;

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

        public IList<MenuItemModel> Items { get; }

        #endregion

        #region Commands

        public ICommand OpenItemCommand { get; }

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

        #endregion
    }
}