using System;
using System.Windows.Input;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingValidationViewModel : ValidatableViewModel
    {
        #region Fields

        private string _property;
        private string _propertyWithException;
        private bool _throw;

        #endregion

        #region Constructors

        public BindingValidationViewModel()
        {
            _propertyWithException = string.Empty;
            Property = string.Empty;
            AddErrorCommand = new RelayCommand(AddError, CanAddError, this);
            RemoveErrorCommand = new RelayCommand(RemoveError, CanRemoveError, this);
        }

        #endregion

        #region Properties

        public string Property
        {
            get { return _property; }
            set
            {
                if (Equals(_property, value))
                    return;
                _property = value;
                if (string.IsNullOrEmpty(value))
                    Validator.SetErrors(nameof(Property), "Validation error");
                else
                    Validator.ClearErrors(nameof(Property));
                OnPropertyChanged();
            }
        }

        public string PropertyWithException
        {
            get { return _propertyWithException; }
            set
            {
                if (Equals(_propertyWithException, value))
                    return;
                _propertyWithException = value;
                OnPropertyChanged();
                _throw = !_throw;
                if (_throw)
                    throw new Exception("Property exception");
            }
        }

        #endregion

        #region Commands

        public ICommand AddErrorCommand { get; }

        public ICommand RemoveErrorCommand { get; }

        private void AddError(object o)
        {
            Validator.SetErrors(nameof(PropertyWithException), "Custom error");
        }

        private bool CanAddError(object o)
        {
            return !CanRemoveError(o);
        }

        private void RemoveError(object o)
        {
            Validator.ClearErrors(nameof(PropertyWithException));
        }

        private bool CanRemoveError(object o)
        {
            return Validator.GetErrors(nameof(PropertyWithException)).Count != 0;
        }

        #endregion
    }
}