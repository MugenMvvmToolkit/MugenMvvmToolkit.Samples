using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.Infrastructure
{
    public abstract class FileRepositoryBase : IRepository
    {
        #region Nested types

        [DataContract]
        public struct ComplexKey : IEquatable<ComplexKey>
        {
            #region Equality members

            public bool Equals(ComplexKey other)
            {
                return Key1.Equals(other.Key1) && Key2.Equals(other.Key2);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is ComplexKey && Equals((ComplexKey)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Key1.GetHashCode() * 397) ^ Key2.GetHashCode();
                }
            }

            #endregion

            #region Fields

            [DataMember]
            public readonly Guid Key1;

            [DataMember]
            public readonly Guid Key2;

            #endregion

            #region Constructors

            public ComplexKey(Guid key1, Guid key2)
                : this()
            {
                Key1 = key1;
                Key2 = key2;
            }

            #endregion

            #region Overrides

            public override string ToString()
            {
                return string.Format("Key1: {0}, Key2: {1}", Key1, Key2);
            }

            #endregion
        }

        [DataContract]
        public sealed class ItemContainer
        {
            #region Fields

            [DataMember]
            public readonly Dictionary<ComplexKey, OrderProductModel> OrderToProducts;
            [DataMember]
            public readonly Dictionary<Guid, OrderModel> Orders;
            [DataMember]
            public readonly Dictionary<Guid, ProductModel> Products;

            #endregion

            #region Constructors

            public ItemContainer()
            {
                Products = new Dictionary<Guid, ProductModel>();
                Orders = new Dictionary<Guid, OrderModel>();
                OrderToProducts = new Dictionary<ComplexKey, OrderProductModel>();
            }

            public ItemContainer(Dictionary<Guid, OrderModel> orders,
                Dictionary<ComplexKey, OrderProductModel> orderToProducts, Dictionary<Guid, ProductModel> products)
            {
                Orders = orders;
                OrderToProducts = orderToProducts;
                Products = products;
            }

            #endregion
        }

        #endregion

        #region Fields

        private const int WaitTime = 500;
        private readonly Task<ItemContainer> _container;

        #endregion

        #region Constructors

        public FileRepositoryBase()
        {
            _container = LoadDataInternalAsync();
        }

        #endregion

        #region Methods

        private async Task<ItemContainer> LoadDataInternalAsync()
        {
            var itemContainer = await LoadDataAsync();
            if (itemContainer == null)
            {
                itemContainer = GetDefaultContainer();
                await SaveDataAsync(itemContainer);
            }
            return itemContainer;
        }

        protected abstract Task<ItemContainer> LoadDataAsync();

        protected abstract Task SaveDataAsync(ItemContainer container);

        protected virtual ItemContainer GetDefaultContainer()
        {
            var productModels = new Dictionary<Guid, ProductModel>();
            for (int i = 1; i <= 250; i++)
            {
                var productModel = new ProductModel
                {
                    Name = "Product " + i,
                    Price = i * 10,
                    Id = Guid.NewGuid()
                };
                productModel.Description = productModel.Name + " description";
                productModels.Add(productModel.Id, productModel);
            }
            return new ItemContainer(new Dictionary<Guid, OrderModel>(), new Dictionary<ComplexKey, OrderProductModel>(),
                productModels);
        }

        private static void UpdateProduct(ItemContainer container, IEntityStateEntry entry)
        {
            var model = (ProductModel)entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added:
                    container.Products.Add(model.Id, model);
                    break;
                case EntityState.Deleted:
                    container.Products.Remove(model.Id);
                    break;
                case EntityState.Modified:
                    if (!container.Products.ContainsKey(model.Id))
                        throw new InvalidOperationException(string.Format("The product with key = {0} not found.",
                            model.Id));
                    container.Products[model.Id] = model;
                    break;
            }
        }

        private static void UpdateOrder(ItemContainer container, IEntityStateEntry entry)
        {
            var model = (OrderModel)entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added:
                    container.Orders.Add(model.Id, model);
                    break;
                case EntityState.Deleted:
                    container.Orders.Remove(model.Id);
                    break;
                case EntityState.Modified:
                    if (!container.Orders.ContainsKey(model.Id))
                        throw new InvalidOperationException(string.Format("The product with key = {0} not found.",
                            model.Id));
                    container.Orders[model.Id] = model;
                    break;
            }
        }

        private static void UpdateOrderProduct(ItemContainer container, IEntityStateEntry entry)
        {
            var model = (OrderProductModel)entry.Entity;
            var key = new ComplexKey(model.IdOrder, model.IdProduct);
            switch (entry.State)
            {
                case EntityState.Added:
                    container.OrderToProducts.Add(key, model);
                    break;
                case EntityState.Deleted:
                    container.OrderToProducts.Remove(key);
                    break;
                case EntityState.Modified:
                    if (!container.OrderToProducts.ContainsKey(key))
                        throw new InvalidOperationException(string.Format("The product with key = {0} not found.", key));
                    container.OrderToProducts[key] = model;
                    break;
            }
        }

        private static void CheckConstraints(ItemContainer container)
        {
            foreach (var orderProductModel in container.OrderToProducts)
            {
                if (!container.Products.ContainsKey(orderProductModel.Value.IdProduct) ||
                    !container.Orders.ContainsKey(orderProductModel.Value.IdOrder))
                    throw new InvalidOperationException("The constraint from order to products is broken.");
            }
        }

        #endregion

        #region Implementation of IRepository

        public async Task SaveAsync(IEnumerable<IEntityStateEntry> entries, CancellationToken token = default(CancellationToken))
        {
            Should.NotBeNull(entries, "entries");
            await Task.Delay(WaitTime, token);
            ItemContainer container = await _container;
            foreach (IEntityStateEntry entityStateEntry in entries)
            {
                if (entityStateEntry.Entity is ProductModel)
                {
                    UpdateProduct(container, entityStateEntry);
                    continue;
                }
                if (entityStateEntry.Entity is OrderModel)
                {
                    UpdateOrder(container, entityStateEntry);
                    continue;
                }
                if (entityStateEntry.Entity is OrderProductModel)
                {
                    UpdateOrderProduct(container, entityStateEntry);
                    continue;
                }
                throw new NotSupportedException(string.Format("The repository doesn't support the {0} type",
                    entityStateEntry.Entity.GetType()));
            }
            token.ThrowIfCancellationRequested();
            CheckConstraints(container);
            await SaveDataAsync(container);
        }

        public async Task<IList<OrderModel>> GetOrdersAsync(CancellationToken token = default(CancellationToken))
        {
            await Task.Delay(WaitTime, token);
            ItemContainer container = await _container;
            return container.Orders.Values.ToList();
        }

        public async Task<IList<ProductModel>> GetProductsAsync(CancellationToken token = default(CancellationToken))
        {
            await Task.Delay(WaitTime, token);
            ItemContainer container = await _container;
            return container.Products.Values.ToList();
        }

        public async Task<IList<OrderProductModel>> GetProductsByOrderAsync(Guid idOrder, CancellationToken token = default(CancellationToken))
        {
            await Task.Delay(WaitTime, token);
            ItemContainer container = await _container;
            return container.OrderToProducts.Values
                .Where(model => model.IdOrder == idOrder)
                .ToList();
        }

        #endregion
    }
}
