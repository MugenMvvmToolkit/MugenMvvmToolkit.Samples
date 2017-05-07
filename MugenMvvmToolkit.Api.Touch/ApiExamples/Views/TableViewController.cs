using System.Drawing;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

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

            using (var set = new BindingSet<UITableView, TableViewModel>(TableView))
            {
                var editItem = new UIBarButtonItem { Title = "Edit" };
                editItem.Clicked += (sender, args) =>
                {
                    TableView.Editing = !TableView.Editing;
                    NavigationItem.RightBarButtonItem.Title = TableView.Editing ? "Done" : "Edit";
                };
                var addItem = new UIBarButtonItem { Title = "Add" };
                set.Bind(addItem).To(() => (vm, ctx) => vm.AddCommand);
                NavigationItem.RightBarButtonItems = new[] { editItem, addItem };

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar).To(() => (vm, ctx) => vm.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                   .To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
                set.Bind(AttachedMemberConstants.SelectedItem)
                    .To(() => (vm, ctx) => vm.GridViewModel.SelectedItem)
                    .TwoWay();
                set.Bind(this, () => controller => controller.Title)
                   .To(() => (vm, ctx) => vm.GridViewModel.SelectedItem.Name)
                   .WithFallback("Nothing selected");
            }

            TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector, new DefaultTableCellTemplateSelector<TableItemModel>(UITableViewCellStyle.Subtitle,
                (cell, set) =>
                {
                    cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                    set.Bind(cell, AttachedMembers.UITableViewCell.AccessoryButtonTappedEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<TableViewModel>().ItemClickCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell, AttachedMembers.UITableViewCell.DeleteClickEvent)
                        .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<TableViewModel>().RemoveCommand)
                        .OneTime()
                        .WithCommandParameter(() => (m, ctx) => m)
                        .ToggleEnabledState(false);
                    set.Bind(cell, AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                        .To(() => (m, ctx) => "Delete " + m.Name);

                    set.Bind(cell, () => viewCell => viewCell.Selected).To(() => (m, ctx) => m.IsSelected).TwoWay();

                    set.Bind(cell.TextLabel).To(() => (m, ctx) => m.Name);
                    set.Bind(cell.DetailTextLabel).To(() => (m, ctx) => $"Selected: {m.IsSelected}");
                }));
        }

        #endregion
    }
}