using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Validation;
using MugenMvvmToolkit.Models.IoC;
using Validation.Portable.Infrastructure;
using Validation.Portable.Interfaces;
using Validation.Portable.Validators;

namespace Validation.Portable.Modules
{
    public class PortableModule : IModule
    {
        #region Overrides of ModuleBase

        public bool Load(IModuleContext context)
        {
            var container = context.IocContainer;
            if (container != null)
            {
                var validatorProvider = container.Get<IValidatorProvider>();
                //NOTE: Registering validator.
                validatorProvider.Register<UserLoginValidator>();
                container.Bind<IUserRepository, CollectionUserRepository>(DependencyLifecycle.SingleInstance);
            }
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion
    }
}