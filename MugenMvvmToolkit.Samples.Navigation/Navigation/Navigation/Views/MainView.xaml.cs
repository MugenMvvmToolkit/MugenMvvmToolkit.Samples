using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Interfaces.Views;
using Navigation.Portable.ViewModels;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class MainView : TabbedPage, IViewModelAwareView<MainViewModel>
    {
        #region Constructors

        public MainView()
        {
            InitializeComponent();
            var toolbarItem = new ToolbarItem { Text = "Navigate" };
            toolbarItem.Clicked += NavigateOnClick;
            ToolbarItems.Add(toolbarItem);
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion

        #region Methods

        private async void NavigateOnClick(object sender, EventArgs eventArgs)
        {
            //NOTE: we can use the binding in xaml but on iOS ToolbarItem do not look pretty. 
            var buttons = new[]
            {
                "First view model (Modal)",
                "First view model (Page)",
                "First view model (Tab)",
                "Second view model (Modal)",
                "Second view model (Page)",
                "Second view model (Tab)",
                "Navigation (Clear back stack)"
            };
            var result = await DisplayActionSheet("Navigate", "Cancel", null, buttons);
            var index = buttons.IndexOf(result);
            switch (index)
            {
                case 0:
                    ViewModel.ShowFirstWindowCommand.Execute(null);
                    break;
                case 1:
                    ViewModel.ShowFirstPageCommand.Execute(null);
                    break;
                case 2:
                    ViewModel.ShowFirstTabCommand.Execute(null);
                    break;
                case 3:
                    ViewModel.ShowSecondWindowCommand.Execute(null);
                    break;
                case 4:
                    ViewModel.ShowSecondPageCommand.Execute(null);
                    break;
                case 5:
                    ViewModel.ShowSecondTabCommand.Execute(null);
                    break;
                case 6:
                    ViewModel.ShowBackStackPageCommand.Execute(null);
                    break;
            }
        }

        #endregion

        #region Implementation of IViewModelAwareView<MainViewModel>

        public MainViewModel ViewModel { get; set; }

        #endregion
    }
}
