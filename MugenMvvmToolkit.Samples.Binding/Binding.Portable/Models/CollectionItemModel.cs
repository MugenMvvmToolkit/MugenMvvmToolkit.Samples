using MugenMvvmToolkit.Models;

namespace Binding.Portable.Models
{
    public class CollectionItemModel : NotifyPropertyChangedBase
    {
        #region Fields

        private string _name;

        #endregion

        #region Properties

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

        public int Id { get; set; }

        #endregion
    }
}