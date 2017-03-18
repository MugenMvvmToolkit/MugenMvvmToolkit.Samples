﻿using System.Collections.Generic;
using System.Reflection;
using Binding.Portable;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.UWP.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : UwpDesignBootstrapperBase
    {
        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new MugenContainer();
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