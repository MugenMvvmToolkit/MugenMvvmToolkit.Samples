using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace SplitView.XamForms
{
    public class App : Application
    {
        #region Constructors

        public App()
        {
            var bootstrapper = XamarinFormsBootstrapperBase.Current ??
                               new Bootstrapper<Portable.App>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }

        #endregion
    }
}