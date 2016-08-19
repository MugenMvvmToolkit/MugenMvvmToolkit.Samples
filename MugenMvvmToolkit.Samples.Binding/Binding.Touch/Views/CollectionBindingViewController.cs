using Binding.Portable.Models;
using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
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
            
            using (var set = new BindingSet<UITableView, CollectionBindingViewModel>(TableView))
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

                var searchBar = new UISearchBar(new CGRect(0, 0, 320, 44)) { Placeholder = "Filter..." };
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

            TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector,
                new DefaultTableCellTemplateSelector<CollectionItemModel>(UITableViewCellStyle.Subtitle,
                    (cell, set) =>
                    {
                        cell.SetEditingStyle(UITableViewCellEditingStyle.Delete);
                        cell.Accessory = UITableViewCellAccessory.None;
                        cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                        set.Bind(cell, AttachedMembers.UITableViewCell.DeleteClickEvent)
                            .To(() => (vm, ctx) => ctx.Relative<UIViewController>().DataContext<CollectionBindingViewModel>().RemoveCommand)
                            .WithCommandParameter(() => (m, ctx) => ctx.Self().DataContext())
                            .ToggleEnabledState(false);
                        set.Bind(cell, AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                            .To(() => (m, ctx) => string.Format("Delete {0} {1}", m.Name, m.Id));
                        set.Bind(cell.TextLabel).To(() => (m, ctx) => m.Name);
                        set.Bind(cell.DetailTextLabel)
                            .To(() => (m, ctx) => "Id " + m.Id);
                    }));
        }

        #endregion
    }
}