using System.Drawing;
using ApiExamples.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace ApiExamples.Views
{
    [Register("TableTemplateViewController")]
    [ViewModel(typeof (TableViewModel), Constants.TableTemplateView)]
    public class TableTemplateViewController : MvvmTableViewController
    {
        #region Overrides of MvvmTableViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            TableView.AllowsSelection = true;
            TableView.SetCellStyle(UITableViewCellStyle.Subtitle);
            using (var set = new BindingSet<UITableView, TableViewModel>(TableView))
            {
                var editItem = new UIBarButtonItem {Title = "Edit"};
                editItem.Clicked += (sender, args) =>
                {
                    TableView.Editing = !TableView.Editing;
                    NavigationItem.RightBarButtonItem.Title = TableView.Editing ? "Done" : "Edit";
                };
                var addItem = new UIBarButtonItem {Title = "Add"};
                set.Bind(addItem, "Clicked").To(model => model.AddCommand);
                NavigationItem.RightBarButtonItems = new[] {editItem, addItem};

                var searchBar = new UISearchBar(new RectangleF(0, 0, 320, 44)) {Placeholder = "Filter..."};
                set.Bind(searchBar, bar => bar.Text).To(model => model.FilterText).TwoWay();
                TableView.TableHeaderView = searchBar;

                set.Bind(AttachedMemberConstants.ItemsSource)
                    .To(model => model.GridViewModel.ItemsSource);
                set.Bind(AttachedMemberConstants.SelectedItem)
                    .To(model => model.GridViewModel.SelectedItem)
                    .TwoWay();
                set.BindFromExpression("ItemTemplate $cellDataTemplate");
                set.Bind(this, controller => controller.Title)
                    .To(model => model.GridViewModel.SelectedItem.Name)
                    .WithFallback("Nothing selected");
            }
        }

        #endregion
    }
}