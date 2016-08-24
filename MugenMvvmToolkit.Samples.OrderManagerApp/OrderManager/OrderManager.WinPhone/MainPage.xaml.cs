using MugenMvvmToolkit.Xamarin.Forms.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace OrderManager.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new OrderManager.XamForms.App(new PlatformBootstrapperService()));
        }
    }
}