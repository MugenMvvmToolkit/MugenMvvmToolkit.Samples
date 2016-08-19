using MugenMvvmToolkit.Xamarin.Forms.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace Binding.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new Binding.App(new PlatformBootstrapperService()));
        }
    }
}