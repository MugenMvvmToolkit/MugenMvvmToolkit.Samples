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

        #region Commands

        public ICommand AddErrorCommand { get; private set; }

        public ICommand RemoveErrorCommand { get; private set; }

        private void AddError(object o)
        {
            Validator.SetErrors("PropertyWithException", "Custom error");
        }

        private bool CanAddError(object o)
        {
            return !CanRemoveError(o);
        }

        private void RemoveError(object o)
        {
            Validator.ClearErrors("PropertyWithException");
        }

        private bool CanRemoveError(object o)
        {
            return Validator.GetErrors("PropertyWithException").Count != 0;
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
                    Validator.SetErrors("Property", "Validation error");
                else
                    Validator.ClearErrors("Property");
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
                throw new Exception("Property exception");
            }
        }

        #endregion
    }
}