using System.Drawing;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding.Converters;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("TableViewCheckmarkController")]
    [ViewModel(typeof(TableViewModel), Constants.TableViewCheckmark)]
    public class TableViewCheckmarkController : MvvmTableViewController
    {
        #region Overrides of MvvmTableViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            TableView.AllowsSelection = true;
            TableView.AllowsMultipleSelection = true;
            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            using (var set = new BindingSet<UITableView, TableViewModel>(TableView))
            {
                NavigationItem.RightBarButtonItem = new UIBarButtonItem("Invert selection", UIBarButtonItemStyle.Plain, null);
                set.Bind(NavigationItem.RightBarButtonItem).To(() => (vm, ctx) => vm.InvertSelectionCommand);

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar).To(() => (vm, ctx) => vm.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                   .To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
            }

            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.None);
                cell.Accessory = UITableViewCellAccessory.None;
                cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                using (var set = new BindingSet<TableItemModel>())
                {
                    set.Bind(cell, () => c => c.Accessory)
                       .ToSelf(() => (c, ctx) => c.Selected)
                       .WithConverter(BooleanToCheckmarkAccessoryConverter.Instance);

                    set.Bind(cell, () => viewCell => viewCell.Selected).To(() => (model, ctx) => model.IsSelected).TwoWay();
                    set.Bind(cell, () => viewCell => viewCell.Highlighted).To(() => (model, ctx) => model.IsHighlighted).OneWayToSource();
                    set.Bind(cell, () => viewCell => viewCell.Editing).To(() => (model, ctx) => model.Editing).OneWayToSource();

                    set.Bind(cell.TextLabel).To(() => (model, ctx) => model.Name);
                    set.Bind(cell.DetailTextLabel)
                        .To(() => (m, ctx) => string.Format("Selected: {0}, Highlighted: {1}, Editing: {2}", m.IsSelected, m.IsHighlighted, m.Editing));
                }
            });
        }

        #endregion
    }
}