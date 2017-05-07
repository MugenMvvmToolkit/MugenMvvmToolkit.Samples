using MugenMvvmToolkit.Xamarin.Forms.UWP;

namespace Navigation.UWP
{
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Navigation.App(new PlatformBootstrapperService()));
        }

        #endregion
    }
}