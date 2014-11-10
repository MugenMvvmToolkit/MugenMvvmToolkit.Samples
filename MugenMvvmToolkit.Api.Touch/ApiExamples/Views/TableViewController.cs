using System.Drawing;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace ApiExamples.Views
{
    [Register("TableViewController")]
    public class TableViewController : MvvmTableViewController
    {
        #region Overrides of MvvmTableViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            TableView.AllowsSelection = true;
            TableView.AllowsMultipleSelection = false;
            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            using (var set = new BindingSet<UITableView, TableViewModel>(TableView))
            {
                var editItem = new UIBarButtonItem { Title = "Edit" };
                editItem.Clicked += (sender, args) =>
                {
                    TableView.Editing = !TableView.Editing;
                    NavigationItem.RightBarButtonItem.Title = TableView.Editing ? "Done" : "Edit";
                };
                var addItem = new UIBarButtonItem { Title = "Add" };
                set.Bind(addItem, "Clicked").To(model => model.AddCommand);
                NavigationItem.RightBarButtonItems = new[] { editItem, addItem };

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar, bar => bar.Text).To(model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                   .To(model => model.GridViewModel.ItemsSource);
                set.Bind(AttachedMemberConstants.SelectedItem)
                    .To(model => model.GridViewModel.SelectedItem)
                    .TwoWay();
                set.Bind(this, controller => controller.Title)
                   .To(model => model.GridViewModel.SelectedItem.Name)
                   .WithFallback("Nothing selected");
            }

            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                using (var set = new BindingSet<TableItemModel>())
                {
                    set.BindFromExpression(cell, "AccessoryButtonTapped $Rel(UIViewController).DataContext.ItemClickCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");
                    set.BindFromExpression(cell, "DeleteClick $Rel(UIViewController).DataContext.RemoveCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");
                    set.BindFromExpression(cell, "TitleForDeleteConfirmation $Format('Delete {0}', Name)");

                    set.Bind(cell, viewCell => viewCell.Selected).To(model => model.IsSelected).TwoWay();
                    set.Bind(cell, viewCell => viewCell.Highlighted).To(model => model.IsHighlighted).OneWayToSource();
                    set.Bind(cell, viewCell => viewCell.Editing).To(model => model.Editing).OneWayToSource();

                    set.Bind(cell.TextLabel, label => label.Text).To(model => model.Name);
                    set.BindFromExpression(cell.DetailTextLabel,
                        "Text $Format('Selected: {0}, Highlighted: {1}, Editing: {2}', IsSelected, IsHighlighted, Editing)");
                }
            });
        }

        #endregion
    }
}