using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : WpfDesignBootstrapperBase
    {
        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new Portable.App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        #endregion
    }
}