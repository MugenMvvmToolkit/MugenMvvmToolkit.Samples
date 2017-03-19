using MugenMvvmToolkit.Xamarin.Forms.UWP;

namespace SplitView.XamForms.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new XamForms.App(new PlatformBootstrapperService()));
        }
    }
}
