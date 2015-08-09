using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("WrapperPageViewController")]
    public class WrapperPageViewController : MvvmViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<WrapperPageViewModel>())
            {
                set.Bind(this, () => controller => controller.Title).To(() => model => model.DisplayName);

                //Content
                var contentPlaceholder = new UIView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height - 50));
                set.Bind(contentPlaceholder, AttachedMemberConstants.Content).To(() => model => model.ViewModel);
                View.AddSubview(contentPlaceholder);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, View.Frame.Height - 40, View.Bounds.Width, 30);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
                button.SetTitle("Close from wrapper", UIControlState.Normal);
                set.Bind(button, "Click").To(() => model => model.CloseCommand);
                Add(button);
            }
        }
    }
}