using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Views;
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
                set.Bind(View, "IsBusy").To(model => model.IsBusy);
                set.Bind(View, "BusyMessage").To(model => model.BusyMessage);
                set.Bind(this, controller => controller.Title).To(model => model.DisplayName);

                var item = new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
                set.Bind(item, "Clicked").To(model => model.ApplyCommand);
                NavigationItem.RightBarButtonItem = item;

                set.Bind(this, controller => controller.Title).To(model => model.DisplayName);
                set.Bind(View, AttachedMemberConstants.Content).To(model => model.ViewModel);
            }
        }

        #endregion
    }
}