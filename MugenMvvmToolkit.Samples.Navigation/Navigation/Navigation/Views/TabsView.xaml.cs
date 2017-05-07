using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.Xamarin.Forms;
using Navigation.Portable.ViewModels;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class TabsView : IViewModelAwareView<TabsViewModel>
    {
        #region Constructors

        public TabsView()
        {
            InitializeComponent();
            var toolbarItem = new ToolbarItem { Text = "Navigate" };
            toolbarItem.Clicked += NavigateOnClick;
            ToolbarItems.Add(toolbarItem);
        }

        #endregion

        #region Properties

        public TabsViewModel ViewModel { get; set; }

        #endregion

        #region Overrides of Page

        private async void NavigateOnClick(object sender, EventArgs eventArgs)
        {
            var buttons = new[]
            {
                "Add Tab",
                "Add Tab (Presenter)"
            };
            var result = await DisplayActionSheet("Navigate", "Cancel", null, buttons);
            var index = buttons.IndexOf(result);
            switch (index)
            {
                case 0:
                    ViewModel.AddTabCommand.Execute(null);
                    break;
                case 1:
                    ViewModel.AddTabPresenterCommand.Execute(null);
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion
    }
}