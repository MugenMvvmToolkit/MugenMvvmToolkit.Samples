using Binding.Portable.Models;
using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("CollectionBindingViewController")]
    public class CollectionBindingViewController : MvvmTableViewController
    {
        #region Overrides of MvvmTableViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            TableView.AllowsSelection = true;
            TableView.AllowsMultipleSelection = false;
            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            using (var set = new BindingSet<UITableView, CollectionBindingViewModel>(TableView))
            {
                var editItem = new UIBarButtonItem { Title = "Edit" };
                editItem.Clicked += (sender, args) =>
                {
                    TableView.Editing = !TableView.Editing;
                    NavigationItem.RightBarButtonItem.Title = TableView.Editing ? "Done" : "Edit";
                };
                var addItem = new UIBarButtonItem { Title = "Add" };
                set.Bind(addItem, "Clicked").To(() => model => model.AddCommand);
                NavigationItem.RightBarButtonItems = new[] { editItem, addItem };

                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar, () => bar => bar.Text).To(() => model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                    .To(() => model => model.GridViewModel.ItemsSource);
                set.Bind(AttachedMemberConstants.SelectedItem)
                    .To(() => model => model.GridViewModel.SelectedItem)
                    .TwoWay();
                set.Bind(this, () => controller => controller.Title)
                    .To(() => model => model.GridViewModel.SelectedItem.Name)
                    .WithFallback("Nothing selected");
            }

            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                cell.Accessory = UITableViewCellAccessory.None;
                cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                using (var set = new BindingSet<CollectionItemModel>())
                {
                    set.Bind(cell, "DeleteClick")
                        .To(() => m => BindingSyntaxEx.Relative<UIViewController>().DataContext<CollectionBindingViewModel>().RemoveCommand)
                        .WithCommandParameter(() => model => BindingSyntaxEx.Self<object>().DataContext<object>())
                        .ToggleEnabledState(false);
                    set.Bind(cell, "TitleForDeleteConfirmation")
                        .To(() => model => string.Format("Delete {0} {1}", model.Name, model.Id));
                    set.Bind(cell.TextLabel, () => label => label.Text).To(() => model => model.Name);
                    set.Bind(cell.DetailTextLabel, () => label => label.Text)
                        .To(() => model => "Id " + model.Id);
                }
            });
        }

        #endregion
    }
}