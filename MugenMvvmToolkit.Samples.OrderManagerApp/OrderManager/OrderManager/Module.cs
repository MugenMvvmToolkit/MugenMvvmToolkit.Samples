using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using OrderManager.Infrastructure;

namespace OrderManager
{
    public class Module : ModuleBase
    {
        #region Constructors

        public Module()
            : base(false, LoadMode.All, InitializationModulePriority)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            IocContainer.Bind<IWrapperManager, WrapperManagerEx>(DependencyLifecycle.SingleInstance);
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}