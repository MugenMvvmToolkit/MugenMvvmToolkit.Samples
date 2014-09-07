using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using Navigation.Portable.Infrastructure;

namespace Navigation.Portable
{
    public class PortableModule : ModuleBase
    {
        #region Constructors

        public PortableModule()
            : base(false, LoadMode.Runtime)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            IocContainer.Bind<IViewModelWrapperManager, ViewModelWrapperManager>(DependencyLifecycle.SingleInstance);
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}