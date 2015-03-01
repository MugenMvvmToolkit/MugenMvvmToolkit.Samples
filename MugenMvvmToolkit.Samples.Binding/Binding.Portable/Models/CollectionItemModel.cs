using MugenMvvmToolkit.Models;

namespace Binding.Portable.Models
{
    public class CollectionItemModel : NotifyPropertyChangedBase
    {
        private string _name;

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id { get; set; }

        #endregion
    }
}