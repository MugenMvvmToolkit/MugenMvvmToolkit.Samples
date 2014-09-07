using System;
using System.Runtime.Serialization;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    [DataContract]
    public class OrderModel : NotifyPropertyChangedBase
    {
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