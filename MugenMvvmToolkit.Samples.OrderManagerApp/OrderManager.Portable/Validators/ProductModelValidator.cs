using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.Validators
{
    public class ProductModelValidator : ValidatorBase<ProductModel>
    {
        #region Overrides of ValidatorBase

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName)
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            if (PropertyNameEqual(propertyName, model => model.Name))
                ValidateName(propertyName, dictionary);
            else if (PropertyNameEqual(propertyName, model => model.Price))
                ValidatePrice(propertyName, dictionary);
            else if (PropertyNameEqual(propertyName, model => model.Description))
                ValidateDescription(propertyName, dictionary);
            return FromResult(dictionary);
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync()
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            ValidateDescription(GetPropertyName(model => model.Description), dictionary);
            ValidateName(GetPropertyName(model => model.Name), dictionary);
            ValidatePrice(GetPropertyName(model => model.Price), dictionary);
            return FromResult(dictionary);
        }

        #endregion

        #region Methods

        private void ValidateDescription(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Description)
                ? string.Format(UiResources.RequiredFieldErrorMessageFormat, key)
                : null;
        }

        private void ValidateName(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Name)
                ? string.Format(UiResources.RequiredFieldErrorMessageFormat, key)
                : null;
        }

        private void ValidatePrice(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = Instance.Price < 0
                ? string.Format(UiResources.NonNegativeErrorMessageFormat, key)
                : null;
        }

        #endregion
    }
}