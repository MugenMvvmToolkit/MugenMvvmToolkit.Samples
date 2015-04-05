using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.ViewModels.Orders;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Portable.ViewModels
{
    public class MainViewModel : MultiViewModel
    {
        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter)
        {
            Should.NotBeNull(viewModelPresenter, "viewModelPresenter");
            viewModelPresenter.DynamicPresenters.Add(new DynamicMultiViewModelPresenter(this));

            OpenProductsCommand = RelayCommandBase.FromAsyncHandler(OpenProducts);
            OpenOrdersCommand = RelayCommandBase.FromAsyncHandler(OpenOrders);
        }

        #endregion

        #region Commands

        public ICommand OpenProductsCommand { get; private set; }

        public ICommand OpenOrdersCommand { get; private set; }

        private async Task OpenOrders()
        {
            using (var orderWorkspaceViewModel = GetViewModel<OrderWorkspaceViewModel>())
                await orderWorkspaceViewModel.ShowAsync();
        }

        private async Task OpenProducts()
        {
            using (var productWorkspaceViewModel = GetViewModel<ProductWorkspaceViewModel>())
                await productWorkspaceViewModel.ShowAsync();
        }

        #endregion
    }
}