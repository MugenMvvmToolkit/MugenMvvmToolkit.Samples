using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using Validation.Portable.ViewModels;

namespace Validation.Touch.Views
{
    [Register("MainViewController")]
    public class MainViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<MainViewModel>())
            {
                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 70, View.Frame.Width - 20, 30);
                button.SetTitle("Validation using data annotations", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.ShowAnnotationCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 100, View.Frame.Width - 20, 30);
                button.SetTitle("Validation using validators", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.ShowUserEditorCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}