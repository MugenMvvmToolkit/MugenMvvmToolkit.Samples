using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.Touch
{
    public class LinkerInclude
    {
        private void Include()
        {
            ValidationAttribute attribute = new RequiredAttribute();
            var validationContext = new ValidationContext(this, null, new Dictionary<object, object>());
            validationContext.DisplayName = validationContext.DisplayName;
            validationContext.Items.Add(null, null);
            validationContext.MemberName = validationContext.MemberName;
            validationContext.ObjectInstance.GetHashCode();

            ValidationResult result = attribute.GetValidationResult(this, validationContext);
            result.ErrorMessage = result.ErrorMessage;
            result.MemberNames.GetHashCode();
        }
    }
}