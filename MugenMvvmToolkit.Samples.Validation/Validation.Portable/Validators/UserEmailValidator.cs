using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using Validation.Portable.Models;

namespace Validation.Portable.Validators
{
    // NOTE: I specifically created two different validator for user model in a real application, it may be one.
    public class UserEmailValidator : ValidatorBase<UserModel>
    {
        #region Overrides of ValidatorBase

        /// <summary>
        ///     Updates information about errors in the specified property.
        /// </summary>
        /// <param name="propertyName">The specified property name.</param>
        /// <returns>
        ///     The result of validation.
        /// </returns>
        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName)
        {
            if (!PropertyNameEqual(propertyName, model => model.Email) || string.IsNullOrEmpty(Instance.Email) ||
                Instance.Email.StartsWith("e"))
                return EmptyResult;
            return FromResult(new Dictionary<string, IEnumerable>
            {
                {propertyName, "The email should starts with 'e'"}
            });
        }

        /// <summary>
        ///     Updates information about all errors.
        /// </summary>
        /// <returns>
        ///     The result of validation.
        /// </returns>
        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync()
        {
            return ValidateInternalAsync(GetPropertyName(model => model.Email));
        }

        #endregion
    }
}