using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces.Validation;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using Validation.Portable.Infrastructure;
using Validation.Portable.Interfaces;
using Validation.Portable.Validators;

namespace Validation.Portable.Modules
{
    public class PortableModule : ModuleBase
    {
        #region Constructors

        public PortableModule()
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
            var validatorProvider = IocContainer.Get<IValidatorProvider>();
            //NOTE: Registering validator.
            validatorProvider.Register<UserLoginValidator>();
            IocContainer.Bind<IUserRepository, CollectionUserRepository>(DependencyLifecycle.SingleInstance);
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