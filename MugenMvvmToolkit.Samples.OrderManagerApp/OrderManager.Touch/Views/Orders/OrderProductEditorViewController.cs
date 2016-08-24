using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Converters;
using UIKit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Views;
using OrderManager.Portable.Models;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Touch.Views.Orders
{
    [Register("OrderProductEditorViewController")]
    public class OrderProductEditorViewController : MvvmTableViewController
    {
        #region Constructors

        public OrderProductEditorViewController()
        {
            Title = "Products";
        }

        #endregion

        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            if (TabBarController != null)
            {
                EdgesForExtendedLayout = UIRectEdge.All;
                TableView.ContentInset = new UIEdgeInsets(
                        UIApplication.SharedApplication.StatusBarFrame.Height +
                        NavigationController.NavigationBar.Frame.Height, 0f, TabBarController.TabBar.Frame.Height, 0f);
            }
            var cellTemplateSelector = new DefaultTableCellTemplateSelector<SelectableWrapper<ProductModel>>(UITableViewCellStyle.Subtitle, (cell, set) =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.None);
                cell.Accessory = UITableViewCellAccessory.None;
                set.Bind(cell, () => viewCell => viewCell.Selected)
                    .To(() => (vm, ctx) => vm.IsSelected)
                    .TwoWay();
                set.Bind(cell.TextLabel)
                    .To(() => (vm, ctx) => vm.Model.Name);
                set.Bind(cell.DetailTextLabel)
                    .To(() => (vm, ctx) => vm.Model.Description);
                set.Bind(cell, () => v => v.Accessory)
                    .ToSelf(() => (vm, ctx) => vm.Selected)
                    .WithConverter(BooleanToCheckmarkAccessoryConverter.Instance);
            }, true);
            TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector, cellTemplateSelector);
            using (var set = new BindingSet<OrderEditorViewModel>())
            {
                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar).To(() => (vm, ctx) => vm.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(TableView, AttachedMembers.UIView.ItemsSource).To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
            }

            TableView.AllowsMultipleSelection = true;
        }

        #endregion
    }
}