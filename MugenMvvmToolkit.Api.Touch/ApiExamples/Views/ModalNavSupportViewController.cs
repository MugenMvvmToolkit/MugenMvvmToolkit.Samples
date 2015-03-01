using ApiExamples.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.Views;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("ModalNavSupportViewController")]
    [ViewModel(typeof (ModalViewModel), Constants.ModalNavSupportView)]
    public class ModalNavSupportViewController : MvvmViewController, IModalNavSupportView
    {
        #region Overrides of UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            Title = "Modal view";

            using (var set = new BindingSet<ModalViewModel>())
            {
                UIButton button = UIButton.FromType(UIButtonType.RoundedRect);
                button.Frame = new CGRect(0, 70, View.Bounds.Width, 30);
                button.SetTitle("Navigate", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.NavigateCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.RoundedRect);
                button.Frame = new CGRect(0, View.Bounds.Height - 50, View.Bounds.Width, 30);
                button.SetTitle("Close modal dialog", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}