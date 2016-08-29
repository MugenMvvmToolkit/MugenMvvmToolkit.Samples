using MugenMvvmToolkit.Xamarin.Forms.WinRT;

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
