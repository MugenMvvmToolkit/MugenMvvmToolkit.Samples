using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;

namespace SplitView.XamForms
{
    public class App : MvvmXamarinApplicationBase
    {
        #region Constructors

        public App(XamarinFormsBootstrapperBase.IPlatformService platformService) : base(platformService)
        {
        }

        #endregion

        #region Methods

        protected override XamarinFormsBootstrapperBase CreateBootstrapper(XamarinFormsBootstrapperBase.IPlatformService platformService, IDataContext context)
        {
            return new Bootstrapper<Portable.App>(platformService, new MugenContainer());
        }

        #endregion
    }
}