using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using SplitView.Portable.Models;

namespace SplitView.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public MainViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _toastPresenter = toastPresenter;
            var items = new List<MenuItemModel>();
            for (var i = 0; i < 10; i++)
            {
                var item = new MenuItemModel();
                item.Id = i;
                item.Name = "Item " + i;
                items.Add(item);
            }
            Items = items;
            OpenItemCommand = new RelayCommand<MenuItemModel>(OpenItem);
        }

        #endregion

        #region Properties

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
                _toastPresenter.ShowAsync("Closed " + vm.DisplayName, ToastDuration.Short);
            }
        }

        #endregion
    }
}