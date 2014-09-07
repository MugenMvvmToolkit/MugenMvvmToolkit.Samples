using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Tests.ViewModels.Products
{
    [TestClass]
    public class ProductEditorViewModelTest : TestBase
    {
        #region Methods

        [TestMethod]
        public void VmShouldUseResourceNameNewEntity()
        {
            var model = new ProductModel();
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, true);
            Assert.AreEqual(viewModel.DisplayName, UiResources.ProductNewDisplayName);
        }

        [TestMethod]
        public void VmShouldUseResourceNameEditEntity()
        {
            var model = new ProductModel();
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);
            Assert.AreEqual(viewModel.DisplayName, UiResources.ProductEditDisplayName);
        }

        [TestMethod]
        public void VmShouldNotBeValidNameIsNull()
        {
            var model = new ProductModel
            {
                Description = "test",
                Id = Guid.NewGuid(),
                Price = 100
            };
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);

            Assert.IsFalse(viewModel.IsValid);
            viewModel.Name = "test";
            viewModel.ValidateAsync(editorViewModel => editorViewModel.Name);
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldNotBeValidDescriptionIsNull()
        {
            var model = new ProductModel
            {
                Name = "test",
                Id = Guid.NewGuid(),
                Price = 100
            };
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);

            Assert.IsFalse(viewModel.IsValid);
            viewModel.Description = "test";
            viewModel.ValidateAsync(editorViewModel => editorViewModel.Description);
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldNotBeValidPriceLessThanZero()
        {
            var model = new ProductModel
            {
                Name = "test",
                Description = "test",
                Id = Guid.NewGuid(),
                Price = -1
            };
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);

            Assert.IsFalse(viewModel.IsValid);
            viewModel.Price = 1;
            viewModel.ValidateAsync(editorViewModel => editorViewModel.Price);
            Assert.IsTrue(viewModel.IsValid);
        }

        [TestMethod]
        public void VmShouldReturnChangesOnlyForProductModel()
        {
            var model = new ProductModel
            {
                Name = "test",
                Description = "test",
                Id = Guid.NewGuid(),
                Price = 10
            };
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);
            IEntityStateEntry entityStateEntry = viewModel.ApplyChanges().Single();
            Assert.AreEqual(entityStateEntry.Entity, model);
        }

        [TestMethod]
        public void VmShouldSaveAndRestoreState()
        {
            var model = new ProductModel
            {
                Name = "test",
                Description = "test",
                Id = Guid.NewGuid(),
                Price = 10
            };
            var viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.InitializeEntity(model, false);

            var state = new DataContext();
            viewModel.SaveState(state);
            state = UpdateState(state);

            viewModel = GetViewModel<ProductEditorViewModel>();
            viewModel.LoadState(state);

            Assert.IsTrue(viewModel.IsEntityInitialized);
            Assert.IsFalse(viewModel.IsNewRecord);
            Assert.AreEqual(viewModel.Name, model.Name);
            Assert.AreEqual(viewModel.Description, model.Description);
            Assert.AreEqual(viewModel.Price, model.Price);
            Assert.AreEqual(viewModel.Entity.Id, model.Id);
        }

        #endregion
    }
}