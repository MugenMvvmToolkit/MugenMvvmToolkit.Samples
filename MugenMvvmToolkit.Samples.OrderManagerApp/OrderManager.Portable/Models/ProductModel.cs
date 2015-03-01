using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    [DataContract]
    public class ProductModel : NotifyPropertyChangedBase
    {
        #region Nested types

        private static readonly IEqualityComparer<ProductModel> KeyComparerInstance = new KeyEqualityComparer();

        public static IEqualityComparer<ProductModel> KeyComparer
        {
            get { return KeyComparerInstance; }
        }

        private sealed class KeyEqualityComparer : IEqualityComparer<ProductModel>
        {
            public bool Equals(ProductModel x, ProductModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._id.Equals(y._id);
            }

            public int GetHashCode(ProductModel obj)
            {
                return obj._id.GetHashCode();
            }
        }

        #endregion

        #region Fields

        private string _description;
        private Guid _id;
        private string _name;
        private decimal _price;

        #endregion

        #region Properties

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (value.Equals(_id)) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}