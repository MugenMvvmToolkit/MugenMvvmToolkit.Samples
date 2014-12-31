using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using Validation.Portable.Models;

namespace Validation.Portable.Validators
{
    //NOTE: This validator is used on platforms that do not support DataAnnotations.
    public class ValidatableModelMetadataValidator : ValidatorBase<ValidatableModel>
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
            var dictionary = new Dictionary<string, IEnumerable>();
            if (PropertyNameEqual(propertyName, model => model.Description))
                ValidateDescription(propertyName, dictionary);
            else if (PropertyNameEqual(propertyName, model => model.Name))
                ValidateName(propertyName, dictionary);
            else
                return DoNothingResult;
            return FromResult(dictionary);
        }

        /// <summary>
        ///     Updates information about all errors.
        /// </summary>
        /// <returns>
        ///     The result of validation.
        /// </returns>
        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync()
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            ValidateName(GetPropertyName(model => model.Name), dictionary);
            ValidateDescription(GetPropertyName(model => model.Description), dictionary);
            return FromResult(dictionary);
        }

        #endregion

        #region Methods

        private void ValidateName(string key, IDictionary<string, IEnumerable> dictionary)
        {
            if (string.IsNullOrEmpty(Instance.Name))
                dictionary[key] = string.Format(PortableResources.RequiredFieldFormat, key);
            else if (Instance.Name.Length < 2 || Instance.Name.Length > 10)
                dictionary[key] = string.Format(PortableResources.StringLengthFieldFormat3, key, 2, 10);
            else
                dictionary[key] = null;
        }

        private void ValidateDescription(string key, IDictionary<string, IEnumerable> dictionary)
        {
            string errorFromVm;
            if (Context.ValidationMetadata.TryGetData(ValidationDataConstants.CustomError, out errorFromVm))
                dictionary[key] = errorFromVm;
            else if (string.IsNullOrEmpty(Instance.Description))
                dictionary[key] = string.Format(PortableResources.RequiredFieldFormat, key);
            else if (Instance.Description.Length < 2 || Instance.Description.Length > 500)
                dictionary[key] = string.Format(PortableResources.StringLengthFieldFormat3, key, 2, 500);
            else
                dictionary[key] = null;
        }

        #endregion
    }
}