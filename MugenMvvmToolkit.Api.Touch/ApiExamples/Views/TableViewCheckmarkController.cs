using System.Drawing;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
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
                set.Bind(NavigationItem.RightBarButtonItem, "Clicked").To(model => model.InvertSelectionCommand);

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) { Placeholder = "Filter..." };
                set.Bind(searchBar, bar => bar.Text).To(model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                   .To(model => model.GridViewModel.ItemsSource);
            }

            TableView.SetCellBind(cell =>
            {
                cell.SetEditingStyle(UITableViewCellEditingStyle.None);
                cell.Accessory = UITableViewCellAccessory.None;
                cell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

                using (var set = new BindingSet<TableItemModel>())
                {
                    set.BindFromExpression(cell, "Accessory $BoolToCheckmark($self.Selected)");

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