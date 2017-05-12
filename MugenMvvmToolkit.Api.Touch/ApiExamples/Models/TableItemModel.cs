using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
    public class TableItemModel : NotifyPropertyChangedBase
    {
        #region Fields

        private bool _isSelected;
        private string _name;

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

        #endregion
    }
}