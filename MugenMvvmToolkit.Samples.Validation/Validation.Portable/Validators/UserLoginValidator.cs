using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Validation;
using MugenMvvmToolkit.Interfaces.Validation;
using Validation.Portable.Interfaces;
using Validation.Portable.Models;

namespace Validation.Portable.Validators
{
    // NOTE: I specifically created two different validator for user model in a real application, it may be one.
    public class UserLoginValidator : ValidatorBase<UserModel>
    {
        #region Fields

        private IUserRepository _userRepository;

        #endregion

        #region Overrides of ValidatorBase

        /// <summary>
        ///     Initializes the current validator using the specified
        ///     <see cref="T:MugenMvvmToolkit.Interfaces.Validation.IValidatorContext" />.
        /// </summary>
        /// <param name="context">
        ///     The specified <see cref="T:MugenMvvmToolkit.Interfaces.Validation.IValidatorContext" />.
        /// </param>
        protected override void OnInitialized(IValidatorContext context)
        {
            _userRepository = context.ServiceProvider.GetService<IUserRepository>();
        }

        /// <summary>
        ///     Updates information about errors in the specified property.
        /// </summary>
        /// <param name="propertyName">The specified property name.</param>
        /// <returns>
        ///     The result of validation.
        /// </returns>
        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName)
        {
            if (!PropertyNameEqual(propertyName, model => model.Login))
                return EmptyResult;
            // To simulate the long-term operation.
            return Task<IDictionary<string, IEnumerable>>.Factory.StartNew(() =>
            {
                ToolkitExtensions.Sleep(500);
                if (_userRepository.GetUsers().Any(model => model != Instance && model.Login == Instance.Login))
                    return new Dictionary<string, IEnumerable>
                    {
                        {
                            propertyName,
                            string.Format("The user with login {0}, already exists.", Instance.Login)
                        }
                    };
                return null;
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
            return ValidateInternalAsync(GetPropertyName(model => model.Login));
        }

        #endregion
    }
}