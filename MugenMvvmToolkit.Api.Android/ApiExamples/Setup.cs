using ApiExamples;
using ApiExamples.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Android.Attributes;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit.Interfaces;

[assembly: Bootstrapper(typeof(Setup))]

namespace ApiExamples
{
    public class Setup : AndroidBootstrapperBase
    {
        #region Overrides of AndroidBootstrapperBase

        protected override IMvvmApplication CreateApplication()
        {
            return new DefaultApp(typeof(MainViewModel));
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        #endregion
    }
}