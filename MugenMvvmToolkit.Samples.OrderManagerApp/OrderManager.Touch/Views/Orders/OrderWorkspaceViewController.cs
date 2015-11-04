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
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Touch.Views.Orders
{
    [Register("OrderWorkspaceViewController")]
    public class OrderWorkspaceViewController : MvvmTableViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<OrderWorkspaceViewModel>())
            {
                set.Bind(this, () => controller => controller.Title).To(() => (vm, ctx) => vm.DisplayName);

                var addItem = new UIBarButtonItem("Add", UIBarButtonItemStyle.Plain, null);
                set.Bind(addItem).To(() => (vm, ctx) => vm.AddOrderCommand);

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

            TableView.SetCellStyle(UITableViewCellStyle.Default);
            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                using (var set = new BindingSet<OrderModel>())
                {
                    set.Bind(cell, AttachedMembers.UITableViewCell.AccessoryButtonTappedEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<OrderWorkspaceViewModel>().EditOrderCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell, AttachedMembers.UITableViewCell.DeleteClickEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<OrderWorkspaceViewModel>().RemoveOrderCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell.TextLabel)
                        .To(() => (m, ctx) => string.Format("{0} (№ {1})", m.Name, m.Number));
                    set.Bind(cell, AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                        .To(() => (m, ctx) => string.Format("Delete {0}", m.Name));
                }
            });
        }

        #endregion
    }
}