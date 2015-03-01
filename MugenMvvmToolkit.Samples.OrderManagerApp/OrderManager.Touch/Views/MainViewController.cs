using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Touch.Views
{
    [Register("MainViewController")]
    public class MainViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Main view";
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<MainViewModel>())
            {
                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 65, View.Frame.Width - 40, 30);
                button.SetTitle("Products", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.OpenProductsCommand);
                View.AddSubview(button);


                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 95, View.Frame.Width - 40, 30);
                button.SetTitle("Orders", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.OpenOrdersCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}