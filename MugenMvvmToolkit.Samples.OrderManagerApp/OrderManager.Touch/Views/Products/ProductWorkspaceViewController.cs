using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Binding;
using UIKit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Touch.Views.Products
{
    [Register("ProductWorkspaceViewController")]
    public class ProductWorkspaceViewController : MvvmTableViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<ProductWorkspaceViewModel>())
            {
                set.Bind(this, () => controller => controller.Title).To(() => (vm, ctx) => vm.DisplayName);

                var addItem = new UIBarButtonItem("Add", UIBarButtonItemStyle.Plain, null);
                set.Bind(addItem).To(() => (vm, ctx) => vm.AddProductCommand);

                var saveItem = new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
                set.Bind(saveItem).To(() => (vm, ctx) => vm.SaveChangesCommand);
                NavigationItem.RightBarButtonItems = new[] { addItem, saveItem };

                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar).To(() => (vm, ctx) => vm.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(View, AttachedMembersEx.UIView.IsBusy).To(() => (vm, ctx) => vm.IsBusy);
                set.Bind(View, AttachedMembersEx.UIView.BusyMessage).To(() => (vm, ctx) => vm.BusyMessage);

                set.Bind(TableView, AttachedMembers.UIView.ItemsSource).To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
                set.Bind(TableView, AttachedMembers.UITableView.SelectedItem)
                    .To(() => (vm, ctx) => vm.GridViewModel.SelectedItem)
                    .TwoWay();
            }

            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
                using (var set = new BindingSet<ProductModel>())
                {
                    set.Bind(cell, AttachedMembers.UITableViewCell.AccessoryButtonTappedEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<ProductWorkspaceViewModel>().EditProductCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell, AttachedMembers.UITableViewCell.DeleteClickEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<ProductWorkspaceViewModel>().RemoveProductCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell.TextLabel)
                       .To(() => (m, ctx) => m.Name);
                    set.Bind(cell.DetailTextLabel)
                       .To(() => (m, ctx) => m.Description);
                    set.Bind(cell, AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                        .To(() => (m, ctx) => string.Format("Delete {0}", m.Name));
                }
            });
        }

        #endregion
    }
}