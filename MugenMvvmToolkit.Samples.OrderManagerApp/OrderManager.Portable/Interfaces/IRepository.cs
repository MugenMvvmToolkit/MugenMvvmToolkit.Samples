using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.Models;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.Interfaces
{
    public interface IRepository
    {
        Task<IList<OrderModel>> GetOrdersAsync(CancellationToken token = default(CancellationToken));

        Task<IList<ProductModel>> GetProductsAsync(CancellationToken token = default(CancellationToken));

        Task<IList<OrderProductModel>> GetProductsByOrderAsync(Guid idOrder,
            CancellationToken token = default(CancellationToken));

        Task SaveAsync(IEnumerable<IEntityStateEntry> entries, CancellationToken token = default(CancellationToken));
    }
}