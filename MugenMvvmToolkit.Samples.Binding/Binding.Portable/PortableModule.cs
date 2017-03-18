using Binding.Portable.Infrastructure;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;

namespace Binding.Portable
{
    public class PortableModule : IModule
    {
        #region Overrides of ModuleBase

        public bool Load(IModuleContext context)
        {
            //NOTE: You can use the custom extension methods in bindings.
            BindingServiceProvider
                .ResourceResolver
                .AddType(typeof(CustomExtensionMethods).Name, typeof(CustomExtensionMethods));

            if (context.IocContainer != null)
            {
                if (context.Mode == LoadMode.Design)
                {
                    var localizationManager = new LocalizationManager();
                    context.IocContainer.BindToConstant<ILocalizationManager>(localizationManager);
                }
                else
                {
                    if (!context.IocContainer.CanResolve<ILocalizationManager>())
                        context.IocContainer.Bind<ILocalizationManager, LocalizationManager>(DependencyLifecycle.SingleInstance);
                }
                context.IocContainer.Bind<IResourceMonitor, ResourceMonitor>(DependencyLifecycle.SingleInstance);
            }

            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        public int Priority => int.MinValue;

        #endregion
    }
}