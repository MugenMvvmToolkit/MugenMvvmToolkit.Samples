using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using OrderManager.Android.Infrastructure;
using OrderManager.Portable.Interfaces;

namespace OrderManager.Android
{
    public class AndroidModule : ModuleBase
    {
        #region Constructors

        public AndroidModule()
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