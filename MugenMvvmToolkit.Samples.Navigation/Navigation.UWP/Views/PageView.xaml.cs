using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MugenMvvmToolkit.UWP;

namespace Navigation.UWP.Views
{
    public sealed partial class PageView : Page
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public PageView()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
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