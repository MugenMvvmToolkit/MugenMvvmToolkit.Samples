using MugenMvvmToolkit;
using MugenMvvmToolkit.Android.Attributes;
using MugenMvvmToolkit.Android.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using SplitView.Android;
using SplitView.Portable;

[assembly: Bootstrapper(typeof (Setup))]

namespace SplitView.Android
{
    public class Setup : AndroidBootstrapperBase
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

        #endregion
    }
}