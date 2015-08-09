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
                set.Bind(this, () => controller => controller.Title).To(() => model => model.DisplayName);

                var addItem = new UIBarButtonItem("Add", UIBarButtonItemStyle.Plain, null);
                set.Bind(addItem, "Clicked").To(() => model => model.AddProductCommand);

                var saveItem = new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
                set.Bind(saveItem, "Clicked").To(() => model => model.SaveChangesCommand);
                NavigationItem.RightBarButtonItems = new[] { addItem, saveItem };

                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar, () => bar => bar.Text).To(() => model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(View, "IsBusy").To(() => model => model.IsBusy);
                set.Bind(View, "BusyMessage").To(() => model => model.BusyMessage);

                set.Bind(TableView, AttachedMembers.UIView.ItemsSource).To(() => model => model.GridViewModel.ItemsSource);
                set.Bind(TableView, AttachedMembers.UITableView.SelectedItem)
                    .To(() => model => model.GridViewModel.SelectedItem)
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
                        .To(() => m => BindingSyntaxEx.Relative<UIViewController>().DataContext<ProductWorkspaceViewModel>().EditProductCommand)
                        .WithCommandParameter(() => model => BindingSyntaxEx.Self<object>().DataContext())
                        .ToggleEnabledState(false);
                    set.Bind(cell, AttachedMembers.UITableViewCell.DeleteClickEvent)
                        .To(() => m => BindingSyntaxEx.Relative<UIViewController>().DataContext<ProductWorkspaceViewModel>().RemoveProductCommand)
                        .WithCommandParameter(() => model => BindingSyntaxEx.Self<object>().DataContext())
                        .ToggleEnabledState(false);
                    set.Bind(cell.TextLabel, () => label => label.Text)
                       .To(() => model => model.Name);
                    set.Bind(cell.DetailTextLabel, () => label => label.Text)
                       .To(() => model => model.Description);
                    set.Bind(cell, AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                        .To(() => m => string.Format("Delete {0}", m.Name));
                }
            });
        }

        #endregion
    }
}