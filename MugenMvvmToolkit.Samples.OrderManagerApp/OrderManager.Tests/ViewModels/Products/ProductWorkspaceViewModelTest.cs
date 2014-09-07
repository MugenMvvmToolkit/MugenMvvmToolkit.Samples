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
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Tests.ViewModels.Products
{
    [TestClass]
    public class ProductWorkspaceViewModelTest : TestBase
    {
        #region Methods

        [TestMethod]
        public void VmShouldLoadProductsFromRepository()
        {
            var productModels = new List<ProductModel> { new ProductModel() };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(productModels));
            RepositoryMock.Verify(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdAlwaysCanBeExecuted()
        {
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsTrue(viewModel.AddProductCommand.CanExecute(null));
        }

        [TestMethod]
        public void EditCmdCannotBeExecutedSelectedItemNull()
        {
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsFalse(viewModel.EditProductCommand.CanExecute(null));
        }

        [TestMethod]
        public void EditCmdCanBeExecutedSelectedItemNotNull()
        {
            var productModels = new List<ProductModel> { new ProductModel() };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = productModels[0];

            Assert.IsNotNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsTrue(viewModel.EditProductCommand.CanExecute(null));
        }

        [TestMethod]
        public void RemoveCmdCannotBeExecutedSelectedItemNull()
        {
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsFalse(viewModel.RemoveProductCommand.CanExecute(null));
        }

        [TestMethod]
        public void RemoveCmdCanBeExecutedSelectedItemNotNull()
        {
            var productModels = new List<ProductModel> { new ProductModel() };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = productModels[0];

            Assert.IsNotNull(viewModel.GridViewModel.SelectedItem);
            Assert.IsTrue(viewModel.RemoveProductCommand.CanExecute(null));
        }

        [TestMethod]
        public void SaveCmdCannotBeExecutedHasChangesFalse()
        {
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsFalse(viewModel.SaveChangesCommand.CanExecute(null));
        }

        [TestMethod]
        public void SaveCmdCanBeExecutedHasChangesTrue()
        {
            SetupEditableWrapper(true);
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);

            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.SaveChangesCommand.CanExecute(null));
        }

        [TestMethod]
        public void VmShouldApplyFilterByNameOrDescription()
        {
            var productModels = new List<ProductModel>
            {
                new ProductModel {Name = "name"},
                new ProductModel {Description = "desc"}
            };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();

            Assert.IsTrue(viewModel.GridViewModel.ItemsSource.SequenceEqual(productModels));
            viewModel.FilterText = productModels[0].Name;
            Assert.AreEqual(viewModel.GridViewModel.ItemsSource.Single(), productModels[0]);
            viewModel.FilterText = productModels[1].Description;
            Assert.AreEqual(viewModel.GridViewModel.ItemsSource.Single(), productModels[1]);
        }

        [TestMethod]
        public void AddCmdShouldShowProductEditorViewModel()
        {
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(false,
                vm => Assert.IsInstanceOfType(vm, typeof(ProductEditorViewModel)));
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdShouldNotAddChangesResultFalse()
        {
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(false);
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();

            viewModel.AddProductCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void AddCmdShouldAddChangesResultTrue()
        {
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(true);
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();

            viewModel.AddProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsNotNull(viewModel.GridViewModel.OriginalItemsSource.Single());
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void EditCmdShouldUseSelectedItemToShowProductEditorViewModel()
        {
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };
            bool isInitialized = false;
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(false, vm =>
            {
                var editorViewModel = (ProductEditorViewModel)vm;
                editorViewModel.EntityInitialized += (model, args) =>
                {
                    Assert.AreEqual(args.OriginalEntity, items[0]);
                    isInitialized = true;
                };
            });
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditProductCommand.Execute(null);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            Assert.IsTrue(isInitialized);
        }

        [TestMethod]
        public void EditCmdShouldUseCommandParameterToShowProductEditorViewModel()
        {
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };
            bool isInitialized = false;
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(false, vm =>
            {
                var editorViewModel = (ProductEditorViewModel)vm;
                editorViewModel.EntityInitialized += (model, args) =>
                {
                    Assert.AreEqual(args.OriginalEntity, items[0]);
                    isInitialized = true;
                };
            });
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = null;

            viewModel.EditProductCommand.Execute(items[0]);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
            Assert.IsTrue(isInitialized);
        }

        [TestMethod]
        public void EditCmdShouldNotAddChangesResultFalse()
        {
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(false);
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditProductCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void EditCmdShouldAddChangesResultTrue()
        {
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };
            Mock<IEditorWrapperViewModel> wrapper = SetupEditableWrapper(true);
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.EditProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            ViewModelPresenterMock.Verify(model => model.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void RemoveCmdShouldNotAddChangesResultNo()
        {
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };

            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.No));
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.RemoveProductCommand.Execute(null);
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
            var items = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid()}
            };

            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));
            InitializeProductRepository(items);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.GridViewModel.SelectedItem = items[0];

            viewModel.RemoveProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
            MessageBoxMock
                .Verify(model => model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                        It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
        }

        [TestMethod]
        public void SaveCmdShouldSaveChangesToRepository()
        {
            RepositoryMock
                .Setup(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            SetupEditableWrapper(true);
            InitializeProductRepository();

            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);

            viewModel.SaveChangesCommand.Execute(null);
            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock
                .Verify(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public void VmShouldBeClosedWithoutMessageHasChangesFalse()
        {
            InitializeProductRepository();
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsTrue(viewModel.CloseAsync(null).Result);
        }

        [TestMethod]
        public void VmShouldBeClosedWithoutSaveChangesHasChangesResultNo()
        {
            RepositoryMock
                .Setup(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.No));
            SetupEditableWrapper(true);
            InitializeProductRepository();

            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(model => model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestMethod]
        public void VmShouldBeClosedSaveChangesHasChangesResultYes()
        {
            RepositoryMock
                .Setup(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));
            SetupEditableWrapper(true);
            InitializeProductRepository();

            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsTrue(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(model => model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        [TestMethod]
        public void VmShouldNotBeClosedHasChangesResultCancel()
        {
            RepositoryMock
                .Setup(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()))
                .Returns(() => Empty.TrueTask);
            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Cancel));
            SetupEditableWrapper(true);
            InitializeProductRepository();

            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.AddProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.IsFalse(viewModel.CloseAsync(null).Result);

            MessageBoxMock
                .Verify(model => model.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNoCancel,
                            MessageImage.Question, It.IsAny<MessageResult>(), It.IsAny<IDataContext>()), Times.Once);
            RepositoryMock
                .Verify(repository => repository.SaveAsync(It.IsAny<IEnumerable<IEntityStateEntry>>(), It.IsAny<CancellationToken>()),
                    Times.Never);
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreStateHasChangesFalse()
        {
            var productModels = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid(), Name = "Test"},
                new ProductModel {Id = Guid.NewGuid(), Name = "Test"},
            };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(productModels));
            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()), Times.Once);

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            RepositoryMock.ResetCalls();
            viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.LoadState(state);

            Assert.IsFalse(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(productModels));
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreStateHasChangesTrue()
        {
            var productModels = new List<ProductModel>
            {
                new ProductModel {Id = Guid.NewGuid(), Name = "Test"}
            };
            InitializeProductRepository(productModels);
            var viewModel = GetViewModel<ProductWorkspaceViewModel>();
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.SequenceEqual(productModels));
            RepositoryMock.Verify(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()), Times.Once);

            MessageBoxMock
                .Setup(box => box.ShowAsync(It.IsAny<string>(), It.IsAny<string>(), MessageButton.YesNo, MessageImage.Question,
                            It.IsAny<MessageResult>(), It.IsAny<IDataContext>()))
                .Returns(Task.FromResult(MessageResult.Yes));

            viewModel.GridViewModel.SelectedItem = productModels[0];

            viewModel.RemoveProductCommand.Execute(null);
            Assert.IsTrue(viewModel.HasChanges);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            RepositoryMock.ResetCalls();
            viewModel = GetViewModel<ProductWorkspaceViewModel>();
            viewModel.LoadState(state);

            Assert.IsTrue(viewModel.HasChanges);
            RepositoryMock.Verify(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.AreEqual(viewModel.GridViewModel.OriginalItemsSource.Count, 0);
        }

        private void InitializeProductRepository(IList<ProductModel> productModels = null)
        {
            if (productModels == null)
                productModels = new ProductModel[0];
            Task<IList<ProductModel>> result = Task.FromResult(productModels);
            RepositoryMock
                .Setup(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()))
                .Returns(() => result);
        }

        #endregion
    }
}