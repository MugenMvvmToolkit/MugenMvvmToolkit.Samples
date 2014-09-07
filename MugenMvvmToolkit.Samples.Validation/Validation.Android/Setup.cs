using System;
using MugenMvvmToolkit;
using Validation.Android;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using Validation.Portable.ViewModels;

[assembly: Bootstrapper(typeof (Setup))]

namespace Validation.Android
{
    public class Setup : AndroidBootstrapperBase
    {
        #region Overrides of AndroidBootstrapperBase

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        protected override Type GetMainViewModelType()
        {
            return typeof (MainViewModel);
        }

        #endregion
    }
}