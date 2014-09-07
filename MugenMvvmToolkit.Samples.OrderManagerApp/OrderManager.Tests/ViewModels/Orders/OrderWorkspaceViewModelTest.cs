using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Tests.ViewModels.Orders
{
    [TestClass]
    public class OrderWorkspaceViewModelTest : TestBase
    {
        #region Methods

        [TestMethod]
        public void VmShouldLoadOrdersFromRepository()
        {
            var models = new List<OrderModel> { new OrderModel() };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(models));
            RepositoryMock.Verify(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdAlwaysCanBeExecuted()
        {
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsTrue(viewModel.AddOrderCommand.CanExecute(null));
        }

        [TestMethod]
        public void EditCmdCannotBeExecutedSelectedItemNull()
        {
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsFalse(viewModel.EditOrderCommand.CanExecute(null));
        }

        [TestMethod]
        public void EditCmdCanBeExecutedSelectedItemNotNull()
        {
            var models = new List<OrderModel> { new OrderModel() };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = models[0];

            Assert.IsNotNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsTrue(viewModel.EditOrderCommand.CanExecute(null));
        }

        [TestMethod]
        public void RemoveCmdCannotBeExecutedSelectedItemNull()
        {
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsFalse(viewModel.RemoveOrderCommand.CanExecute(null));
        }

        [TestMethod]
        public void RemoveCmdCanBeExecutedSelectedItemNotNull()
        {
            var models = new List<OrderModel> { new OrderModel() };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = models[0];

            Assert.IsNotNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsTrue(viewModel.RemoveOrderCommand.CanExecute(null));
        }

        [TestMethod]
        public void SaveCmdCannotBeExecutedHasChangesFalse()
        {
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsFalse(viewModel.SaveChangesCommand.CanExecute(null));
        }

        [TestMethod]
        public void SaveCmdCanBeExecutedHasChangesTrue()
        {
            SetupEditableWrapper(true);
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);

            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.SaveChangesCommand.CanExecute(null));
        }

        [TestMethod]
        public void VmShouldApplyFilterByNameOrNumber()
        {
            var models = new List<OrderModel>
            {
                new OrderModel {Name = "name"},
                new OrderModel {Number = "number"}
            };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();

            Assert.IsTrue(viewModel.GridViewModel.ItemsSource.SequenceEqual(models));
            viewModel.FilterText = models[0].Name;
            Assert.AreEqual(viewModel.GridViewModel.ItemsSource.Single(), models[0]);
            viewModel.FilterText = models[1].Number;
            Assert.AreEqual(viewModel.GridViewModel.ItemsSource.Single(), models[1]);
        }

        [TestMethod]
        public void AddCmdShouldShowOrderEditorViewModel()
        {
            var wrapper = SetupEditableWrapper(false, vm => Assert.IsInstanceOfType(vm, typeof(OrderEditorViewModel)));
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdShouldNotAddChangesResultFalse()
        {
            var wrapper = SetupEditableWrapper(false);
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();

            viewModel.AddOrderCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdShouldAddChangesResultTrue()
        {
            var wrapper = SetupEditableWrapper(true);
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();

            viewModel.AddOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsNotNull(viewModel.GridViewModel.OriginalItemsSource.Single());
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void EditCmdShouldUseSelectedItemToShowOrderEditorViewModel()
        {
            var items = new List<OrderModel>
            {
                new OrderModel
                {
                    Id = Guid.NewGuid()
                }
            };
            bool isInitialized = false;
            IList<OrderProductModel> links = new List<OrderProductModel> { new OrderProductModel() };
            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(links));
            var wrapper = SetupEditableWrapper(false, vm =>
            {
                var editorViewModel = (OrderEditorViewModel)vm;
                editorViewModel.EntityInitialized += (model, args) =>
                {
                    Assert.AreEqual(args.OriginalEntity, items[0]);
                    Assert.IsTrue(editorViewModel.OldLinks.SequenceEqual(links));
                    isInitialized = true;
                };
            });
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditOrderCommand.Execute(null);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock.Verify(
                repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsTrue(isInitialized);
        }

        [TestMethod]
        public void EditCmdShouldUseCommandParameterToShowOrderEditorViewModel()
        {
            var items = new List<OrderModel>
            {
                new OrderModel
                {
                    Id = Guid.NewGuid()
                }
            };
            bool isInitialized = false;
            IList<OrderProductModel> links = new List<OrderProductModel> { new OrderProductModel() };
            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(links));
            var wrapper = SetupEditableWrapper(false, vm =>
            {
                var editorViewModel = (OrderEditorViewModel)vm;
                editorViewModel.EntityInitialized += (model, args) =>
                {
                    Assert.AreEqual(args.OriginalEntity, items[0]);
                    Assert.IsTrue(editorViewModel.OldLinks.SequenceEqual(links));
                    isInitialized = true;
                };
            });
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = null;

            viewModel.EditOrderCommand.Execute(items[0]);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock.Verify(
                repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsTrue(isInitialized);
        }

        [TestMethod]
        public void EditCmdShouldNotAddChangesResultFalse()
        {
            var items = new List<OrderModel>
            {
                new OrderModel {Id = Guid.NewGuid()}
            };
            IList<OrderProductModel> links = new List<OrderProductModel>();
            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(links));
            var wrapper = SetupEditableWrapper(false);
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditOrderCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock.Verify(
                repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void EditCmdShouldAddChangesResultTrue()
        {
            var items = new List<OrderModel>
            {
                new OrderModel {Id = Guid.NewGuid()}
            };
            IList<OrderProductModel> links = new List<OrderProductModel>();
            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(links));
            var wrapper = SetupEditableWrapper(true);
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock.Verify(
                repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void RemoveCmdShouldNotAddChangesResultNo()
        {
            var items = new List<OrderModel>
            {
                new OrderModel {Id = Guid.NewGuid()}
            };

            MessageBoxMock
                .Setup(
                    box =>
                        box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.No));
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.RemoveOrderCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(items));
            MessageBoxMock.Verify(
                model =>
                    model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                        It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void RemoveCmdShouldAddChangesResultYes()
        {
            var items = new List<OrderModel>
            {
                new OrderModel {Id = Guid.NewGuid()}
            };
            IList<OrderProductModel> links = new List<OrderProductModel>();
            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(links));
            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));
            InitializeRepository(items);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.RemoveOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
            MessageBoxMock.Verify(
                model =>
                    model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                        It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock.Verify(
                repository => repository.GetProductsByOrderAsync(items[0].Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void SaveCmdShouldSaveChangesToRepository()
        {
            RepositoryMock
                .Setup(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            SetupEditableWrapper(true);
            InitializeRepository();

            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);

            viewModel.SaveChangesCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock.Verify(
                repository =>
                    repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [TestMethod]
        public void VmShouldBeClosedWithoutMessageHasChangesFalse()
        {
            InitializeRepository();
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsTrue(viewModel.CloseAsync(null).Result);
        }

        [TestMethod]
        public void VmShouldBeClosedWithoutSaveChangesHasChangesAndResultNo()
        {
            RepositoryMock
                .Setup(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(
                    box =>
                        box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.No));
            SetupEditableWrapper(true);
            InitializeRepository();

            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(
                    model =>
                        model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                    Times.Never);
        }

        [TestMethod]
        public void VmShouldBeClosedWithSaveChangesHasChangesAndResultYes()
        {
            RepositoryMock
                .Setup(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(
                    box =>
                        box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));
            SetupEditableWrapper(true);
            InitializeRepository();

            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(
                    model =>
                        model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        [TestMethod]
        public void VmShouldNotBeClosedHasChangesAndResultCancel()
        {
            RepositoryMock
                .Setup(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(
                    box =>
                        box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Cancel));
            SetupEditableWrapper(true);
            InitializeRepository();

            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.AddOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsFalse(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(
                    model =>
                        model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(
                    repository =>
                        repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                    Times.Never);
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreStateHasChangesFalse()
        {
            var models = new List<OrderModel> { new OrderModel() };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(models));
            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()), Times.Once);

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            RepositoryMock.ResetCalls();
            viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.LoadState(state);

            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(models));
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreStateHasChangesTrue()
        {
            var models = new List<OrderModel> { new OrderModel() };
            InitializeRepository(models);
            var viewModel = GetViewModel<OrderWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(models));
            RepositoryMock.Verify(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()), Times.Once);

            RepositoryMock
                .Setup(repository => repository.GetProductsByOrderAsync(models[0].Id, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<IList<OrderProductModel>>(Empty.Array<OrderProductModel>()));
            MessageBoxMock
                .Setup(
                    box =>
                        box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));
            viewModel.GridViewModel.SelectedItem = models[0];

            viewModel.RemoveOrderCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            RepositoryMock.ResetCalls();
            viewModel = GetViewModel<OrderWorkspaceViewModel>();
            viewModel.LoadState(state);

            Assert.IsTrue(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
        }

        private void InitializeRepository(IList<OrderModel> orderModels = null, IList<ProductModel> productModels = null)
        {
            if (orderModels == null)
                orderModels = new OrderModel[0];
            if (productModels == null)
                productModels = new ProductModel[0];
            Task<IList<OrderModel>> result = Task.FromResult(orderModels);
            Task<IList<ProductModel>> productResult = Task.FromResult(productModels);
            RepositoryMock
                .Setup(repository => repository.GetOrdersAsync(It.IsAny<CancellationToken>()))
                .Returns(result);
            RepositoryMock
                .Setup(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()))
                .Returns(productResult);
        }

        #endregion

    }
}