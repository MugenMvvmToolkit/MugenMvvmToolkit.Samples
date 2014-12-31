using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace Navigation.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new Navigation.App());
        }
    }
}