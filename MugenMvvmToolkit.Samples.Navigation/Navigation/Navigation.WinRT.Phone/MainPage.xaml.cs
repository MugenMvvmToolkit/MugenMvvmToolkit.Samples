using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using MugenMvvmToolkit.Xamarin.Forms.WinRT;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Navigation.WinRT.Phone
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Navigation.App(new PlatformBootstrapperService()));
        }
    }
}