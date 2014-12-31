using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using OrderManager.Infrastructure;
using OrderManager.Portable.Interfaces;

namespace OrderManager
{
    public class WinRTModule : ModuleBase
    {
        #region Constructors

        public WinRTModule()
            : base(false, LoadMode.Runtime)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            IocContainer.BindToConstant<IRepository>(new FileRepository());
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}