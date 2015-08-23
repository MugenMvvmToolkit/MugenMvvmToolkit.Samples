using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("BackStackViewController")]
    public class BackStackViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<BackStackViewModel>())
            {
                var label = new UILabel(new CGRect(0, 70, View.Frame.Width, 30));
                set.Bind(label).To(() => vm => "Back stack depth " + vm.Depth);
                View.AddSubview(label);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 100, View.Frame.Width, 30);
                button.SetTitle("Navigate to next view", UIControlState.Normal);
                set.Bind(button).To(() => model => model.NavigateCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 130, View.Frame.Width, 30);
                button.SetTitle("Navigate to main view model (Clear back stack)", UIControlState.Normal);
                set.Bind(button).To(() => model => model.NavigateClearBackStackCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}