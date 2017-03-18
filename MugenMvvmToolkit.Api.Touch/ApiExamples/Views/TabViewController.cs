using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("TabViewController")]
    public class TabViewController : MvvmTabBarController
    {
        #region Overrides of MvvmTabBarController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<TabViewModel>())
            {
                NavigationItem.RightBarButtonItems = new[]
                {
                    new UIBarButtonItem {Title = "Add"},
                    new UIBarButtonItem {Title = "Insert"},
                    new UIBarButtonItem {Title = "Remove"}
                };
                set.Bind(NavigationItem.RightBarButtonItems[0]).To(() => (vm, ctx) => vm.AddCommand);
                set.Bind(NavigationItem.RightBarButtonItems[1]).To(() => (vm, ctx) => vm.InsertCommand);
                set.Bind(NavigationItem.RightBarButtonItems[2]).To(() => (vm, ctx) => vm.RemoveCommand);

                set.Bind(this, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(this, AttachedMemberConstants.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
                set.Bind(this, () => controller => controller.Title).To(() => (vm, ctx) => ((ItemViewModel)vm.SelectedItem).Id);
            }
        }

        #endregion
    }
}