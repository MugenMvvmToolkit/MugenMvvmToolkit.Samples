using System.ComponentModel;
using System.Runtime.CompilerServices;
using MugenMvvmToolkit;

namespace OrderManager.Portable.Models
{
    public class SelectableWrapper<T> : INotifyPropertyChanged where T : class
    {
        #region Fields

        private bool _isSelected;
        private T _model;

        #endregion

        #region Constructors

        public SelectableWrapper(bool isSelected, T model)
        {
            Should.NotBeNull(model, "model");
            IsSelected = isSelected;
            Model = model;
        }

        #endregion

        #region Properties

        public T Model
        {
            get { return _model; }
            private set
            {
                if (Equals(value, _model)) return;
                _model = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Implementation of interfaces

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}