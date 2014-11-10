using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("WrapperWindowViewController")]
    public class WrapperWindowViewController : MvvmViewController, IModalView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<WrapperWindowViewModel>())
            {
                set.Bind(this, controller => controller.Title).To(model => model.DisplayName);

                //Content
                var contentPlaceholder = new UIView(new RectangleF(0, 0, View.Frame.Width, View.Frame.Height - 50));
                set.Bind(contentPlaceholder, AttachedMemberConstants.Content).To(model => model.ViewModel);
                View.AddSubview(contentPlaceholder);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new RectangleF(0, View.Frame.Height - 40, View.Bounds.Width, 30);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
                button.SetTitle("Close from wrapper", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.CloseCommand);
                Add(button);
            }
        }
    }
}