using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using OrderManager.Portable.ViewModels;
using OrderManager.Portable.ViewModels.Orders;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Tests.ViewModels
{
    [TestClass]
    public class MainViewModelTest : TestBase
    {
        #region Methods

        [TestMethod]
        public void VmShouldInitializeCommandsAndPresenter()
        {
            var viewModel = GetViewModel<MainViewModel>();
            Assert.IsNotNull(viewModel.OpenOrdersCommand, "OpenOrdersCommand is null");
            Assert.IsNotNull(viewModel.OpenProductsCommand, "OpenProductsCommand is null");
            DynamicMultiViewModelPresenter item = ViewModelPresenterMock.Object
                                                                        .DynamicPresenters
                                                                        .OfType<DynamicMultiViewModelPresenter>()
                                                                        .FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void OpenProductsCommandShouldOpenProductWorkspaceViewModel()
        {
            var viewModel = GetViewModel<MainViewModel>();
            Assert.AreEqual(viewModel.ItemsSource.Count, 0);
            viewModel.OpenProductsCommand.Execute(null);
            ViewModelPresenterMock.Verify(
                presenter =>
                    presenter.ShowAsync(It.Is<IViewModel>(model => model is ProductWorkspaceViewModel),
                        It.IsAny<IDataContext>()), Times.Once());
        }

        [TestMethod]
        public void OpenOrdersCommandShouldOpenOrderWorkspaceViewModel()
        {
            var viewModel = GetViewModel<MainViewModel>();
            Assert.AreEqual(viewModel.ItemsSource.Count, 0);
            viewModel.OpenOrdersCommand.Execute(null);
            ViewModelPresenterMock.Verify(
                presenter =>
                    presenter.ShowAsync(It.Is<IViewModel>(model => model is OrderWorkspaceViewModel),
                        It.IsAny<IDataContext>()), Times.Once());
        }

        #endregion
    }
}