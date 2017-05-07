using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Interfaces.Views;
using MugenMvvmToolkit.iOS.Views;
using MugenMvvmToolkit.Interfaces.Views;
using Navigation.Portable.ViewModels;
using UIKit;

namespace Navigation.Touch.Views
{
    [Register("OpenedViewModelsController")]
    public class OpenedViewModelsController : MvvmTableViewController, IEventListener, IViewModelAwareView<OpenedViewModelsViewModel>, IModalView
    {
        #region Properties

        bool IEventListener.IsAlive => true;

        bool IEventListener.IsWeak => false;

        public OpenedViewModelsViewModel ViewModel { get; set; }

        #endregion

        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            TableView.ContentInset = new UIEdgeInsets(24, 0, 0, 0);
            TableView.AllowsSelection = false;
            TableView.AllowsMultipleSelection = false;

            TableView.Bind(AttachedMemberConstants.ItemsSource)
                .To(nameof(OpenedViewModelsViewModel.OpenedViewModels))
                .Build();

            TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector,
                new DefaultTableCellTemplateSelector<OpenedViewModelsViewModel.OpenedViewModelInfo>(UITableViewCellStyle.Default,
                    (cell, set) =>
                    {
                        cell.SetEditingStyle(UITableViewCellEditingStyle.None);
                        cell.Accessory = UITableViewCellAccessory.DetailButton;
                        cell.TextLabel.AdjustsFontSizeToFitWidth = true;
                        cell.SetBindingMemberValue(AttachedMembers.UITableViewCell.AccessoryButtonTappedEvent, this);

                        set.Bind(cell.TextLabel).To(() => (m, ctx) => m.Name);
                    }));
        }

        private void OpenMenu(OpenedViewModelsViewModel.OpenedViewModelInfo viewModelInfo)
        {
            if (viewModelInfo == null)
                return;
            var menuItems = ViewModel.GetMenuItems(viewModelInfo);
            if (menuItems.IsNullOrEmpty())
                return;
            var actionSheet = new UIActionSheet(viewModelInfo.Name);
            foreach (var menuItem in menuItems)
                actionSheet.AddButtonWithCommand(menuItem.Name, menuItem.Command, menuItem.CommandParameter);
            actionSheet.CancelButtonIndex = actionSheet.AddButton("Cancel");
            actionSheet.ShowInView(TableView);
        }

        #endregion

        #region Implementation of interfaces

        public bool TryHandle(object sender, object message)
        {
            OpenMenu(sender.DataContext<OpenedViewModelsViewModel.OpenedViewModelInfo>());
            return true;
        }

        #endregion
    }
}