using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.Infrastructure
{
    public class DesignRepository : IRepository
    {
        #region Implementation of IRepository

        public Task<IList<OrderModel>> GetOrdersAsync(CancellationToken token = new CancellationToken())
        {
            IList<OrderModel> list = new List<OrderModel>();
            for (int i = 1; i <= 30; i++)
            {
                list.Add(new OrderModel
                {
                    CreationDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    Name = "Design data " + i,
                    Number = i.ToString()
                });
            }
            return Task.FromResult(list);
        }

        public Task<IList<ProductModel>> GetProductsAsync(CancellationToken token = new CancellationToken())
        {
            IList<ProductModel> list = new List<ProductModel>();
            for (int i = 1; i <= 30; i++)
            {
                list.Add(new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Design data " + i,
                    Description = "Description " + i,
                    Price = i * 100
                });
            }
            return Task.FromResult(list);
        }

        public Task<IList<OrderProductModel>> GetProductsByOrderAsync(Guid idOrder,
            CancellationToken token = new CancellationToken())
        {
            return Task.FromResult<IList<OrderProductModel>>(Empty.Array<OrderProductModel>());
        }

        public Task SaveAsync(IEnumerable<IEntityStateEntry> entries, CancellationToken token = new CancellationToken())
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}