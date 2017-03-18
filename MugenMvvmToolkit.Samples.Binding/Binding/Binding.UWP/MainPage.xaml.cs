using MugenMvvmToolkit.Xamarin.Forms.UWP;

namespace Binding.UWP
{
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Binding.App(new PlatformBootstrapperService()));
        }

        #endregion
    }
}