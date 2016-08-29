using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Views;
using SplitView.Portable.Models;
using SplitView.Portable.ViewModels;
using UIKit;

namespace SplitView.iOS.Views
{
    [Register("MainViewController")]
    public class MainViewController : MvvmTableViewController
    {
        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            using (var bindingSet = new BindingSet<MainViewModel>())
            {
                bindingSet.Bind(TableView, AttachedMembers.UIView.ItemsSource)
                    .To(() => (vm, ctx) => vm.Items);
                bindingSet.Bind(TableView, AttachedMembers.UITableView.SelectedItemChangedEvent)
                    .To(() => (vm, ctx) => ctx.Relative<UIViewController>().DataContext<MainViewModel>().OpenItemCommand)
                    .WithCommandParameter(() => (item, ctx) => ctx.Self<UITableView>().Member(AttachedMembers.UITableView.SelectedItem));

                TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector, new DefaultTableCellTemplateSelector<MenuItemModel>(UITableViewCellStyle.Default,
                    (cell, set) =>
                    {
                        cell.TextLabel.Bind(() => l => l.Text)
                            .To<MenuItemModel>(() => (vm, ctx) => vm.Name)
                            .Build();
                    }, false));
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            //Clear selected item.
            TableView.SetBindingMemberValue(AttachedMembers.UITableView.SelectedItem, value: null);
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }

        #endregion
    }
}