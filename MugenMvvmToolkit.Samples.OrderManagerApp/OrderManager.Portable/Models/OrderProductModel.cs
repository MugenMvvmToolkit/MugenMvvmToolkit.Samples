using System;
using System.Runtime.Serialization;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    [DataContract]
    public class OrderProductModel : NotifyPropertyChangedBase
    {
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