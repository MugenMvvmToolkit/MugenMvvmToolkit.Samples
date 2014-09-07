#if !PCL
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace Validation.Portable.Attributes
{
    //NOTE: We can not use attributes for validation in the portable assembly because it does not support it. 
    //NOTE: But we can add link to this file and use it on specified platform that supports the attributes.
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
#endif
