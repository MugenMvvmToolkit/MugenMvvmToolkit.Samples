using Binding.Portable.Infrastructure;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;

namespace Binding.Portable
{
    public class PortableModule : ModuleBase
    {
        #region Constructors

        public PortableModule()
            : base(true, LoadMode.Design | LoadMode.Runtime, int.MinValue)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        /// <summary>
        ///     Loads the current module.
        /// </summary>
        protected override bool LoadInternal()
        {
            //NOTE: You can use the custom extension methods in bindings.
            BindingServiceProvider
                .ResourceResolver
                .AddType(typeof(CustomExtensionMethods).Name, typeof(CustomExtensionMethods));

            if (Mode == LoadMode.Design)
            {
                var localizationManager = new LocalizationManager();
                if (IocContainer != null)
                    IocContainer.BindToConstant<ILocalizationManager>(localizationManager);
            }
            else
            {
                if (!IocContainer.CanResolve<ILocalizationManager>())
                    IocContainer.Bind<ILocalizationManager, LocalizationManager>(DependencyLifecycle.SingleInstance);
            }

            if (IocContainer != null)
                IocContainer.Bind<IResourceMonitor, ResourceMonitor>(DependencyLifecycle.SingleInstance);
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