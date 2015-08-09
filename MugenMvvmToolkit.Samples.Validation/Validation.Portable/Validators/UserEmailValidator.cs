using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using Validation.Portable.Models;

namespace Validation.Portable.Validators
{
    // NOTE: I specifically created two different validator for user model in a real application, it may be one.
    public class UserEmailValidator : ValidatorBase<UserModel>
    {
        #region Overrides of ValidatorBase

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName, CancellationToken token)
        {
            if (!MemberNameEqual(propertyName, () => model => model.Email) || string.IsNullOrEmpty(Instance.Email) ||
                Instance.Email.StartsWith("e"))
                return EmptyResult;
            return FromResult(new Dictionary<string, IEnumerable>
            {
                {propertyName, "The email should starts with 'e'"}
            });
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(CancellationToken token)
        {
            return ValidateInternalAsync(GetMemberName(() => model => model.Email), token);
        }

        #endregion
    }
}