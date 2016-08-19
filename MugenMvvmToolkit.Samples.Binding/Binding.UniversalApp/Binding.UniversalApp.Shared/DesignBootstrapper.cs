using System.Collections.Generic;
using System.Reflection;
using Binding.Portable;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.WinRT.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : WinRTDesignBootstrapperBase
    {
        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        protected override IList<Assembly> GetAssembliesInternal()
        {
            return new[]
            {
                typeof(DesignBootstrapper).GetTypeInfo().Assembly,
                typeof(MainViewModel).GetTypeInfo().Assembly
            };
        }

        #endregion
    }
}