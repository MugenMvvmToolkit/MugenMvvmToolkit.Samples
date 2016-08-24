using MugenMvvmToolkit.Xamarin.Forms.WinRT;

namespace OrderManager.WinRT
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new OrderManager.XamForms.App(new PlatformBootstrapperService()));
        }
    }
}