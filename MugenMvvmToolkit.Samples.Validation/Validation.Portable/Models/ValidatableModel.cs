using System.ComponentModel.DataAnnotations;
using MugenMvvmToolkit.Models;
using Validation.Portable.Attributes;

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

        [Required, StringLength(10, MinimumLength = 2)]
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

        [Required, StringLength(500, MinimumLength = 2), OptionalValidation]
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