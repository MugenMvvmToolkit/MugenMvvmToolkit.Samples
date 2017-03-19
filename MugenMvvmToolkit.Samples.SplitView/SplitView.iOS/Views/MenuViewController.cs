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
    public class MenuViewController : MvvmTableViewController
    {
        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

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
                    }));
            }
        }

        #endregion
    }
}