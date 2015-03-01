using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using Validation.Portable.Models;

namespace Validation.Portable.Validators
{
    //NOTE: This validator is used on platforms that do not support DataAnnotations.
    public class UserModelMetadataValidator : ValidatorBase<UserModel>
    {
        #region Overrides of ValidatorBase

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName, CancellationToken token)
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            if (PropertyNameEqual(propertyName, model => model.Login))
                ValidateLogin(propertyName, dictionary);
            else if (PropertyNameEqual(propertyName, model => model.Name))
                ValidateName(propertyName, dictionary);
            return FromResult(dictionary);
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(CancellationToken token)
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            ValidateLogin(GetPropertyName(model => model.Login), dictionary);
            ValidateName(GetPropertyName(model => model.Name), dictionary);
            return FromResult(dictionary);
        }

        #endregion

        #region Methods

        private void ValidateLogin(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Login)
                ? string.Format(PortableResources.RequiredFieldFormat, key)
                : null;
        }

        private void ValidateName(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Name)
                ? string.Format(PortableResources.RequiredFieldFormat, key)
                : null;
        }

        #endregion
    }
}