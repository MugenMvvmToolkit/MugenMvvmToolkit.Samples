using System;
using System.Collections.Generic;
using System.Reflection;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.WinPhone.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : WindowsPhoneDesignBootstrapperBase
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

        protected override IList<Assembly> GetAssembliesInternal()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        #endregion
    }
}