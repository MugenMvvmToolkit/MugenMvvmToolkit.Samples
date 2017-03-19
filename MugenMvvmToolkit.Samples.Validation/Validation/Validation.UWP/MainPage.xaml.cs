using MugenMvvmToolkit.Xamarin.Forms.UWP;

namespace Validation.UWP
{
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Validation.App(new PlatformBootstrapperService()));
        }

        #endregion
    }
}