using CoreGraphics;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("ModalViewController")]
    public class ModalViewController : MvvmViewController, IModalView
    {
        #region Overrides of UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            UIButton button = UIButton.FromType(UIButtonType.RoundedRect);
            button.Frame = new CGRect(0, View.Bounds.Height - 50, View.Bounds.Width, 30);
            button.SetTitle("Close modal dialog", UIControlState.Normal);
            button.SetBindings("Click CloseCommand");

            View.AddSubview(button);
        }

        #endregion
    }
}