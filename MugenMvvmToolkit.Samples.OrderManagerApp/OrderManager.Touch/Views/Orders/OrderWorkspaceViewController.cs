using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
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
                set.Bind(this, controller => controller.Title).To(model => model.DisplayName);

                var addItem = new UIBarButtonItem("Add", UIBarButtonItemStyle.Plain, null);
                set.Bind(addItem, "Clicked").To(model => model.AddOrderCommand);

                var saveItem = new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
                set.Bind(saveItem, "Clicked").To(model => model.SaveChangesCommand);
                NavigationItem.RightBarButtonItems = new[] { addItem, saveItem };

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar, bar => bar.Text).To(model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(View, "IsBusy").To(model => model.IsBusy);
                set.Bind(View, "BusyMessage").To(model => model.BusyMessage);

                set.Bind(TableView, AttachedMemberConstants.ItemsSource).To(model => model.GridViewModel.ItemsSource);
                set.Bind(TableView, AttachedMemberConstants.SelectedItem)
                    .To(model => model.GridViewModel.SelectedItem)
                    .TwoWay();
            }

            TableView.SetCellStyle(UITableViewCellStyle.Default);
            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                using (var set = new BindingSet<OrderModel>())
                {
                    set.BindFromExpression(cell, "AccessoryButtonTapped $Rel(UIViewController).DataContext.EditOrderCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");
                    set.BindFromExpression(cell, "DeleteClick $Rel(UIViewController).DataContext.RemoveOrderCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");

                    set.BindFromExpression(cell.TextLabel, "Text $Format('{0} (№ {1})', Name, Number)");
                    set.BindFromExpression(cell, "TitleForDeleteConfirmation $Format('Delete {0}', Name)");
                }
            });
        }

        #endregion
    }
}