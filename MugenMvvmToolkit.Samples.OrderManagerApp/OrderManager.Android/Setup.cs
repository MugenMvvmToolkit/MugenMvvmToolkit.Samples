using MugenMvvmToolkit;
using MugenMvvmToolkit.Android.Attributes;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using OrderManager.Android;
using OrderManager.Portable;

[assembly: Bootstrapper(typeof (Setup))]

namespace OrderManager.Android
{
    public class Setup : AndroidBootstrapperBase
    {
        #region Overrides of AndroidBootstrapperBase

        protected override IMvvmApplication CreateApplication()
        {
            return new App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        #endregion
    }
}