using Microsoft.Phone.Controls;

namespace SplitView.XamForms.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new SplitView.XamForms.App());
        }
    }
}
