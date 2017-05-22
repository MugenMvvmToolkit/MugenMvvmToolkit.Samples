using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.UWP;
using Navigation.Portable.ViewModels;

namespace Navigation.UWP.Views
{
    public sealed partial class OpenedViewModelsView : IViewModelAwareView<OpenedViewModelsViewModel>
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public OpenedViewModelsView()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
        }

        #endregion

        #region Properties

        public OpenedViewModelsViewModel ViewModel { get; set; }

        #endregion

        #region Methods

        private void OnItemClicked(object sender, PointerRoutedEventArgs e)
        {
            var item = (FrameworkElement)sender;
            var info = item.DataContext as OpenedViewModelsViewModel.OpenedViewModelInfo;
            var menuItems = ViewModel?.GetMenuItems(info);
            if (menuItems.IsNullOrEmpty())
                return;
            var menuFlyout = new MenuFlyout();
            foreach (var menuItem in menuItems)
                menuFlyout.Items.Add(new MenuFlyoutItem { Command = menuItem.Command, CommandParameter = menuItem.CommandParameter, Text = menuItem.Name });
            menuFlyout.ShowAt(item, e.GetCurrentPoint(item).Position);
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