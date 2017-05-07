using MugenMvvmToolkit.Android.Attributes;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using Navigation.Android;
using Navigation.Portable;

[assembly: Bootstrapper(typeof(Setup))]

namespace Navigation.Android
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
            return new MugenContainer();
        }

        #endregion
    }
}