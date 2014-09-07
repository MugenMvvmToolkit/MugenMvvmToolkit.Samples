using MugenMvvmToolkit.Models;

namespace Validation.Portable.Models
{
    //NOTE: you can use attributes to specify metadata.
    //[MetadataType(typeof(ValidatableModelMetadata1))]
    //[MetadataType("GetMetaTypes")]
    public class ValidatableModel : NotifyPropertyChangedBase
    {
        #region Fields

        private string _description;
        private string _name;

        #endregion

        #region Properties

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

        #endregion
    }
}