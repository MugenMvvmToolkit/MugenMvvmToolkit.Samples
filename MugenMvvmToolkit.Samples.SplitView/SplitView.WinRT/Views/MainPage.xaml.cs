using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SplitView.WinRT.Interfaces;

namespace SplitView.WinRT.Views
{
    public sealed partial class MainPage : IFrameView
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            BackRadioButton.Visibility = ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") ? Visibility.Collapsed : Visibility.Visible;
        }

        #endregion

        #region Properties

        public Frame ContentFrame
        {
            get { return (Frame) SplitView.Content; }
            set { SplitView.Content = value; }
        }

        #endregion

        #region Methods

        private void BackRadioButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (ContentFrame != null && ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        private void HamburgerRadioButtonClick(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        #endregion
    }
}