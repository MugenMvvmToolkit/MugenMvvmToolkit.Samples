using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Interfaces.Views;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("ResultViewController")]
    public class ResultViewController : MvvmViewController, ITabView
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<ResultViewModel>())
            {
                var textLb = new UITextField(new CGRect(0, 70, View.Frame.Width, 30)) { TextAlignment = UITextAlignment.Center };
                set.Bind(textLb).To(nameof(ResultViewModel.Result)).TwoWay();
                View.AddSubview(textLb);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 100, View.Frame.Width, 30);
                button.SetTitle("Show Opened View Models", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowOpenedViewModelsCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 130, View.Frame.Width, 30);
                button.SetTitle("Close", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}