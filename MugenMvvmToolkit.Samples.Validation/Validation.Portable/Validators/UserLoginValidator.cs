using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        protected override void OnInitialized(IValidatorContext context)
        {
            _userRepository = context.ServiceProvider.GetService<IUserRepository>();
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName, CancellationToken token)
        {
            if (!MemberNameEqual(propertyName, () => model => model.Login))
                return EmptyResult;
            // To simulate the long-term operation.
            return Task<IDictionary<string, IEnumerable>>.Factory.StartNew(() =>
            {
                ToolkitExtensions.Sleep(500);
                if (token.IsCancellationRequested)
                    return null;
                if (_userRepository.GetUsers().Any(model => model != Instance && model.Login == Instance.Login))
                    return new Dictionary<string, IEnumerable>
                    {
                        {
                            propertyName,
                            $"The user with login {Instance.Login}, already exists."
                        }
                    };
                return null;
            }, token);
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(CancellationToken token)
        {
            return ValidateInternalAsync(GetMemberName(() => model => model.Login), token);
        }

        #endregion
    }
}