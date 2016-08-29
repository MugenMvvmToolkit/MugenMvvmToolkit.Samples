using MugenMvvmToolkit.Xamarin.Forms.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace Validation.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new Validation.App(new PlatformBootstrapperService()));
        }
    }
}