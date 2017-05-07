using System.Linq;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Xamarin.Forms.Interfaces.Views;
using Navigation.Portable.ViewModels;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class OpenedViewModelsView : IModalView, IViewModelAwareView<OpenedViewModelsViewModel>
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

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;

            var openedViewModelInfo = e.Item as OpenedViewModelsViewModel.OpenedViewModelInfo;
            var menuItems = ViewModel?.GetMenuItems(openedViewModelInfo);
            if (menuItems == null)
                return;
            var result = await DisplayActionSheet(openedViewModelInfo.Name, "Cancel", null, menuItems.Select(item => item.Name).ToArray());
            var menuItem = menuItems.FirstOrDefault(item => item.Name == result);
            menuItem?.Command.Execute(menuItem.CommandParameter);
        }

        #endregion
    }
}