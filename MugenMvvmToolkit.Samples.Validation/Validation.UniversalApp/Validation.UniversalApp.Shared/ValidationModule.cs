using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Validation;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using Validation.Portable.Validators;

namespace Validation.UniversalApp
{
    public class ValidationModule : ModuleBase
    {
        #region Constructors

        public ValidationModule()
            : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        /// <summary>
        ///     Loads the current module.
        /// </summary>
        protected override bool LoadInternal()
        {
            var provider = IocContainer.Get<IValidatorProvider>();
            provider.Register<ValidatableModelMetadataValidator>();
            provider.Register<UserModelMetadataValidator>();
            return true;
        }

        /// <summary>
        ///     Unloads the current module.
        /// </summary>
        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}