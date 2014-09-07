using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.Wpf.Infrastructure;

namespace OrderManager.Wpf
{
    public class WpfModule : ModuleBase
    {
        #region Constructors

        public WpfModule()
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