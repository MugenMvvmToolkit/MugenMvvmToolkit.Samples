using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Android.Attributes;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using OrderManager.Android;
using OrderManager.Portable.ViewModels;

[assembly: Bootstrapper(typeof(Setup))]

namespace OrderManager.Android
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
            return typeof(MainViewModel);
        }

        #endregion
    }
}