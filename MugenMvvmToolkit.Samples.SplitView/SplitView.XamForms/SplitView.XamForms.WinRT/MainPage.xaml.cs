 using MugenMvvmToolkit.Xamarin.Forms.WinRT;

namespace SplitView.XamForms.WinRT
{
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new XamForms.App(new PlatformBootstrapperService()));
        }

        #endregion
    }
}