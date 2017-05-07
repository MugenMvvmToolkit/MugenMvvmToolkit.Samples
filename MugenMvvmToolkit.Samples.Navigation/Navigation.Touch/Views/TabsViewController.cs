using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Views;
using MugenMvvmToolkit.Interfaces.Views;
using Navigation.Portable.ViewModels;
using UIKit;

namespace Navigation.Touch.Views
{
    [Register("TabsViewController")]
    public class TabsViewController : MvvmTabBarController, IViewModelAwareView<TabsViewModel>
    {
        #region Properties

        public TabsViewModel ViewModel { get; set; }

        #endregion

        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Tabs view";
            View.BackgroundColor = UIColor.White;

            NavigationItem.RightBarButtonItem = new UIBarButtonItem("Navigation", UIBarButtonItemStyle.Plain,
                (sender, args) =>
                {
                    var actionSheet = new UIActionSheet("Navigation");

                    actionSheet.AddButtonWithCommand("Add Tab", ViewModel.AddTabCommand);
                    actionSheet.AddButtonWithCommand("Add Tab (Presenter)", ViewModel.AddTabPresenterCommand);
                    actionSheet.ShowFrom((UIBarButtonItem)sender, true);
                });


            using (var bindingSet = new BindingSet<TabsViewModel>())
            {
                //TabBar
                bindingSet.Bind(this, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                bindingSet.Bind(this, AttachedMemberConstants.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
            }
        }

        #endregion
    }
}