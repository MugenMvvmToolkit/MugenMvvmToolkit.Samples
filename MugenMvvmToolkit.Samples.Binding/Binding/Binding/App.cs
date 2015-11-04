using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace Binding
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