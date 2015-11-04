using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.iOS.Views;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Touch.Views
{
    [Register("EditorWrapperViewController")]
    public class EditorWrapperViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<EditorWrapperViewModel<IEditableViewModel>>())
            {
                set.Bind(View, AttachedMembersEx.UIView.IsBusy).To(() => (vm, ctx) => vm.IsBusy);
                set.Bind(View, AttachedMembersEx.UIView.BusyMessage).To(() => (vm, ctx) => vm.BusyMessage);
                set.Bind(this, () => controller => controller.Title).To(() => (vm, ctx) => vm.DisplayName);

                var item = new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
                set.Bind(item).To(() => (vm, ctx) => vm.ApplyCommand);
                NavigationItem.RightBarButtonItem = item;

                set.Bind(this, () => controller => controller.Title).To(() => (vm, ctx) => vm.DisplayName);
                set.Bind(View, AttachedMemberConstants.Content).To(() => (vm, ctx) => vm.ViewModel);
            }
        }

        #endregion
    }
}