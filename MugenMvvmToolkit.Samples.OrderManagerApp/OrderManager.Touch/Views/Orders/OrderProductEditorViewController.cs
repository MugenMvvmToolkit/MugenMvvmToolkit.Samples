using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Converters;
using UIKit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
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

            using (var set = new BindingSet<OrderEditorViewModel>())
            {
                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar).To(() => model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(TableView, AttachedMembers.UIView.ItemsSource).To(() => model => model.GridViewModel.ItemsSource);
            }

            TableView.AllowsMultipleSelection = true;
            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.None);
                cell.Accessory = UITableViewCellAccessory.None;
                using (var set = new BindingSet<SelectableWrapper<ProductModel>>())
                {
                    set.Bind(cell, () => viewCell => viewCell.Selected)
                       .To(() => wrapper => wrapper.IsSelected)
                       .TwoWay();
                    set.Bind(cell.TextLabel)
                       .To(() => model => model.Model.Name);
                    set.Bind(cell.DetailTextLabel)
                       .To(() => model => model.Model.Description);
                    set.Bind(cell, () => v => v.Accessory)
                        .ToSelf(() => m => m.Selected)
                        .WithConverter(BooleanToCheckmarkAccessoryConverter.Instance);
                }
            });
        }

        #endregion
    }
}