using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.ViewModels;
using Validation.Portable.Models;

namespace Validation.Portable.ViewModels
{
    public class DataAnnotationViewModel : ValidatableViewModel
    {
        #region Fields

        private string _customError;
        private bool _disableDescriptionValidation;

        #endregion

        #region Constructors

        public DataAnnotationViewModel()
        {
            //Initialize empty value, to avoid null references in properies.
            Model = new ValidatableModel();
        }

        #endregion

        #region Properties

        public ValidatableModel Model { get; set; }

        public string CustomError
        {
            get { return _customError; }
            set
            {
                if (value == _customError) return;
                _customError = value;
                Settings.Metadata.Remove(ValidationDataConstants.CustomError);
                if (!string.IsNullOrWhiteSpace(_customError))
                    Settings.Metadata.Add(ValidationDataConstants.CustomError, value);
                OnPropertyChanged();
                ValidateAsync("Description");
            }
        }

        public bool DisableDescriptionValidation
        {
            get { return _disableDescriptionValidation; }
            set
            {
                if (value.Equals(_disableDescriptionValidation))
                    return;
                _disableDescriptionValidation = value;
                if (value)
                    this.DisableValidationAsync(model => model.Description);
                else
                    this.EnableValidationAsync(model => model.Description);
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     This attributes uses to mapping view model property to model, also you can use this code for do this:
        ///     PropertiesMapping["Name"] = new[] {"NameInVm"};
        /// </summary>
        [ModelProperty("Name")]
        public string NameInVm
        {
            get { return Model.Name; }
            set
            {
                if (Equals(value, Model.Name))
                    return;
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return Model.Description; }
            set
            {
                if (Equals(value, Model.Description))
                    return;
                Model.Description = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}