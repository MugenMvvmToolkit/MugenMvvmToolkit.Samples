using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : XamarinFormsDesignBootstrapperBase
    {
        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new Portable.App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new MugenContainer();
        }

        #endregion
    }
}