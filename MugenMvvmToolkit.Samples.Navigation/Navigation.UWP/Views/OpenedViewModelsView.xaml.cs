using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.UWP.Views
{
    public sealed partial class OpenedViewModelsView : IViewModelAwareView<OpenedViewModelsViewModel>
    {
        #region Constructors

        public OpenedViewModelsView()
        {
            InitializeComponent();
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
            MenuFlyout menuFlyout = new MenuFlyout();
            foreach (var menuItem in menuItems)
                menuFlyout.Items.Add(new MenuFlyoutItem { Command = menuItem.Command, CommandParameter = menuItem.CommandParameter, Text = menuItem.Name });
            menuFlyout.ShowAt(item, e.GetCurrentPoint(item).Position);
        }

        #endregion
    }
}