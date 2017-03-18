using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : WpfDesignBootstrapperBase
    {
        #region Methods

        public DesignBootstrapper()
        {
            BindingServiceProvider.InitializeFromDesignContext();
        }

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