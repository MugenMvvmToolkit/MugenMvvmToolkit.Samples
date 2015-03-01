using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    [DataContract]
    public class OrderModel : NotifyPropertyChangedBase
    {
        #region Nested types

        private static readonly IEqualityComparer<OrderModel> KeyComparerInstance = new KeyEqualityComparer();

        public static IEqualityComparer<OrderModel> KeyComparer
        {
            get { return KeyComparerInstance; }
        }

        private sealed class KeyEqualityComparer : IEqualityComparer<OrderModel>
        {
            public bool Equals(OrderModel x, OrderModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._id.Equals(y._id);
            }

            public int GetHashCode(OrderModel obj)
            {
                return obj._id.GetHashCode();
            }
        }

        #endregion

        #region Fields

        private DateTime _creationDate;
        private Guid _id;
        private string _name;
        private string _number;

        #endregion

        #region Constructors

        public OrderModel()
        {
            _creationDate = DateTime.Now;
        }

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
        public string Number
        {
            get { return _number; }
            set
            {
                if (value == _number) return;
                _number = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                if (value.Equals(_creationDate)) return;
                _creationDate = value;
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