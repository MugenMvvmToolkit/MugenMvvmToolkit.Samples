using MugenMvvmToolkit.Xamarin.Forms.WinRT;

namespace Binding.WinRT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Binding.App(new PlatformBootstrapperService()));
        }
    }
}