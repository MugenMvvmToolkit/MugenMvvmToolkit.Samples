using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
    public class TableItemModel : NotifyPropertyChangedBase
    {
        #region Fields

        private bool _isHighlighted;
        private bool _isSelected;
        private string _name;
        private bool _editing;

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public bool IsHighlighted
        {
            get { return _isHighlighted; }
            set
            {
                if (_isHighlighted == value)
                    return;
                _isHighlighted = value;
                OnPropertyChanged();
            }
        }

        public bool Editing
        {
            get { return _editing; }
            set
            {
                if (_editing == value)
                    return;
                _editing = value; 
                OnPropertyChanged();
            }
        }

        #endregion
    }
}