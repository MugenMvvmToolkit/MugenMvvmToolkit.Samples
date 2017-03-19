using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace Validation.Portable.Attributes
{
    public class OptionalValidationAttribute : ValidationAttribute
    {
        #region Overrides of ValidationAttribute

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IDataContext dataContext = validationContext.Items.ToDataContext();
            string customError;
            if (dataContext.TryGetData(ValidationDataConstants.CustomError, out customError))
                return new ValidationResult(customError, new[] {validationContext.MemberName});
            return ValidationResult.Success;
        }

        #endregion
    }
}