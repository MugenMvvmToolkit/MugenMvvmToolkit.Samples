using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace SplitView.XamForms
{
    public class App : Application
    {
        #region Constructors

        public App(XamarinFormsBootstrapperBase.IPlatformService platformService)
        {
            var bootstrapper = XamarinFormsBootstrapperBase.Current ??
                               new Bootstrapper<Portable.App>(platformService, new AutofacContainer());
            bootstrapper.Start();
        }

        #endregion
    }
}