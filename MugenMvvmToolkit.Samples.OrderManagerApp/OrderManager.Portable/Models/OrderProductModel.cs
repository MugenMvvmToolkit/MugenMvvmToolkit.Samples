using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    [DataContract]
    public class OrderProductModel : NotifyPropertyChangedBase
    {
        #region Nested types

        private static readonly IEqualityComparer<OrderProductModel> KeyComparerInstance = new KeyEqualityComparer();

        public static IEqualityComparer<OrderProductModel> KeyComparer
        {
            get { return KeyComparerInstance; }
        }

        private sealed class KeyEqualityComparer : IEqualityComparer<OrderProductModel>
        {
            public bool Equals(OrderProductModel x, OrderProductModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._idOrder.Equals(y._idOrder) && x._idProduct.Equals(y._idProduct);
            }

            public int GetHashCode(OrderProductModel obj)
            {
                unchecked
                {
                    return (obj._idOrder.GetHashCode()*397) ^ obj._idProduct.GetHashCode();
                }
            }
        }

        #endregion

        #region Fields

        private Guid _idOrder;
        private Guid _idProduct;

        #endregion

        #region Properties

        [DataMember]
        public Guid IdOrder
        {
            get { return _idOrder; }
            set
            {
                if (value.Equals(_idOrder)) return;
                _idOrder = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public Guid IdProduct
        {
            get { return _idProduct; }
            set
            {
                if (value.Equals(_idProduct)) return;
                _idProduct = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}