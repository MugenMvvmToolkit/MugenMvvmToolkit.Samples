using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Tests.ViewModels.Orders
{
    [TestClass]
    public class OrderEditorViewModelTest : TestBase
    {
        #region Methods

        [TestMethod]
        public void VmShouldUseResourceNameNewEntity()
        {
            InitializeRepository();
            var model = new OrderModel();
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, true);
            Assert.AreEqual(viewModel.DisplayName, UiResources.OrderNewDisplayName);
        }

        [TestMethod]
        public void VmShouldUseResourceNameEditEntity()
        {
            InitializeRepository();
            var model = new OrderModel();
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, Enumerable.Empty<OrderProductModel>());
            Assert.AreEqual(viewModel.DisplayName, UiResources.OrderEditDisplayName);
        }

        [TestMethod]
        public void VmShouldLoadProductsFromRepository()
        {
            var models = new[] { new ProductModel(), new ProductModel() };
            InitializeRepository(models);
            var model = new OrderModel();
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, true);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.All(wrapper => !wrapper.IsSelected));
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Select(wrapper => wrapper.Model).SequenceEqual(models));
        }

        [TestMethod]
        public void VmShouldLoadProductsFromRepositoryAndRestoreSelection()
        {
            var models = new[] { new ProductModel(), new ProductModel { Id = Guid.NewGuid() } };
            var links = new[] { new OrderProductModel { IdProduct = models[1].Id } };
            InitializeRepository(models);
            var model = new OrderModel();
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, links);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[1]).IsSelected);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Select(wrapper => wrapper.Model).SequenceEqual(models));
        }

        [TestMethod]
        public void VmShouldNotBeValidNameNull()
        {
            InitializeRepository(new[] { new ProductModel() });
            var model = new OrderModel
            {
                Number = "test",
                Id = Guid.NewGuid()
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, false);
            viewModel.GridViewModel.OriginalItemsSource[0].IsSelected = true;

            Assert.IsFalse(viewModel.IsValid);
            viewModel.Name = "test";
            viewModel.ValidateAsync(() => editorViewModel => editorViewModel.Name);
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldNotBeValidNumberNull()
        {
            InitializeRepository(new[] { new ProductModel() });
            var model = new OrderModel
            {
                Name = "test",
                Id = Guid.NewGuid(),
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, false);
            viewModel.GridViewModel.OriginalItemsSource[0].IsSelected = true;

            Assert.IsFalse(viewModel.IsValid);
            viewModel.Number = "test";
            viewModel.ValidateAsync(() => editorViewModel => editorViewModel.Number);
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldNotBeValidNotSelectedAnyProduct()
        {
            InitializeRepository(new[] { new ProductModel() });
            var model = new OrderModel
            {
                Name = "test",
                Number = "test",
                Id = Guid.NewGuid(),
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, false);

            Assert.IsFalse(viewModel.IsValid);
            viewModel.GridViewModel.OriginalItemsSource[0].IsSelected = true;
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldReturnChangesForOrderAndProductLinks()
        {
            var models = new[]
            {
                new ProductModel {Id = Guid.NewGuid()},
                new ProductModel {Id = Guid.NewGuid()},
                new ProductModel {Id = Guid.NewGuid()}
            };
            InitializeRepository(models);
            var model = new OrderModel
            {
                Name = "test",
                Id = Guid.NewGuid(),
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, Enumerable.Empty<OrderProductModel>());
            viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[0]).IsSelected = true;
            viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[1]).IsSelected = true;

            IList<IEntityStateEntry> changes = viewModel.ApplyChanges();
            Assert.AreEqual(changes.Single(entry => entry.Entity is OrderModel).Entity, model);
            List<IEntityStateEntry> links = changes.Where(entry => entry.Entity is OrderProductModel).ToList();
            Assert.AreEqual(links.Count, 2);
            Assert.IsTrue(links.All(entry => entry.State == EntityState.Added));
            Assert.IsTrue(links.Any(entry => ((OrderProductModel)entry.Entity).IdProduct == models[0].Id));
            Assert.IsTrue(links.Any(entry => ((OrderProductModel)entry.Entity).IdProduct == models[1].Id));
        }

        [TestMethod]
        public void VmShouldRemoveOldLinksUnselected()
        {
            var models = new[]
            {
                new ProductModel {Id = Guid.NewGuid()},
                new ProductModel {Id = Guid.NewGuid()},
                new ProductModel {Id = Guid.NewGuid()}
            };
            var oldLinks = new[] { new OrderProductModel { IdProduct = models[0].Id } };
            InitializeRepository(models);
            var model = new OrderModel
            {
                Name = "test",
                Id = Guid.NewGuid(),
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, oldLinks);
            SelectableWrapper<ProductModel> oldItem = viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[0]);
            Assert.IsTrue(oldItem.IsSelected);
            oldItem.IsSelected = false;

            IList<IEntityStateEntry> changes = viewModel.ApplyChanges();
            Assert.AreEqual(changes.Single(entry => entry.Entity is OrderModel).Entity, model);
            IEntityStateEntry oldLinkEntry = changes.Single(entry => entry.Entity is OrderProductModel);
            Assert.AreEqual(oldLinkEntry.State, EntityState.Deleted);
            Assert.AreEqual(((OrderProductModel)oldLinkEntry.Entity).IdProduct, models[0].Id);
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreState()
        {
            var models = new[] { new ProductModel(), new ProductModel { Id = Guid.NewGuid() } };
            var links = new[] { new OrderProductModel { IdProduct = models[1].Id } };
            InitializeRepository(models);
            var model = new OrderModel
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Name = "Test",
                Number = "1"
            };
            var viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.InitializeEntity(model, links);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[1]).IsSelected);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Select(wrapper => wrapper.Model).SequenceEqual(models));

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            viewModel = GetViewModel<OrderEditorViewModel>();
            viewModel.LoadState(state);

            Assert.IsTrue(viewModel.IsEntityInitialized);
            Assert.AreEqual(viewModel.Name, model.Name);
            Assert.AreEqual(viewModel.Number, model.Number);
            Assert.AreEqual(viewModel.CreationDate, model.CreationDate);
            Assert.AreEqual(viewModel.Entity.Id, model.Id);
            Assert.IsFalse(viewModel.IsNewRecord);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Single(wrapper => wrapper.Model == models[1]).IsSelected);
            Assert.IsTrue(viewModel.GridViewModel.OriginalItemsSource.Select(wrapper => wrapper.Model).SequenceEqual(models));
        }

        private void InitializeRepository(IList<ProductModel> productModels = null)
        {
            if (productModels == null)
                productModels = new ProductModel[0];
            Task<IList<ProductModel>> productResult = Task.FromResult(productModels);
            RepositoryMock
                .Setup(repository => repository.GetProductsAsync(It.IsAny<CancellationToken>()))
                .Returns(productResult);
        }

        #endregion
    }
}