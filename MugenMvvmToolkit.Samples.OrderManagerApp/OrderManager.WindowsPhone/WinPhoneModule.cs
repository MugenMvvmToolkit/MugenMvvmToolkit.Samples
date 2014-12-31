using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using OrderManager.Portable.Interfaces;
using OrderManager.WindowsPhone.Infrastructure;

namespace OrderManager.WindowsPhone
{
    public class WinPhoneModule : ModuleBase
    {
        #region Constructors

        public WinPhoneModule()
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