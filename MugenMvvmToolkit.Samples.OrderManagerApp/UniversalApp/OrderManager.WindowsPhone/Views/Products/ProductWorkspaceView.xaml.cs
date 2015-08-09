using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using MugenMvvmToolkit.WinRT.Binding;

namespace OrderManager.Views.Products
{
    public sealed partial class ProductWorkspaceView : Page
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public ProductWorkspaceView()
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

        #region Methods

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            HeaderPanel.Visibility = Visibility.Collapsed;
            FilterTb.Visibility = Visibility.Visible;
            FilterTb.Focus(FocusState.Programmatic);
        }

        private void FilterTbOnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilterTb.Text))
                return;
            HeaderPanel.Visibility = Visibility.Visible;
            FilterTb.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_OnHolding(object sender, HoldingRoutedEventArgs e)
        {
            var senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            if (flyoutBase != null)
                flyoutBase.ShowAtEx(senderElement);
        }

        #endregion
    }
}