using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using MugenMvvmToolkit.UWP;

namespace SplitView.WinRT.Views
{
    public sealed partial class MainPage
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
        }

        #endregion

        #region Methods

        private void HamburgerRadioButtonClick(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        #endregion

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}