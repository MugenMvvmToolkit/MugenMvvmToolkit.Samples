using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.WindowsPhone.Infrastructure;

namespace OrderManager.WindowsPhone
{
    public class WindowsPhoneModule : ModuleBase
    {
        #region Constructors

        public WindowsPhoneModule()
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