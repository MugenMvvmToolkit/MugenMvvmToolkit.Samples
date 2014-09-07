using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;

namespace OrderManager.Portable.Models
{
    public class SelectableWrapper<T> : NotifyPropertyChangedBase where T : class
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
    }
}