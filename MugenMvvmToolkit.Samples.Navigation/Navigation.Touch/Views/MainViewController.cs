using CoreGraphics;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    public class MainViewController : MvvmViewController
    {
        #region Overrides of UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Main view";
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<MainViewModel>())
            {
                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 70, View.Frame.Width - 20, 30);
                button.SetTitle("Page Navigation", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowPageCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 100, View.Frame.Width - 20, 30);
                button.SetTitle("Dialog Navigation", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowDialogCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 130, View.Frame.Width - 20, 30);
                button.SetTitle("View Model With Result", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowResultCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 160, View.Frame.Width - 20, 30);
                button.SetTitle("Tabs Navigation", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowTabsCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 190, View.Frame.Width - 20, 30);
                button.SetTitle(@"App Background\Foreground Navigation", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowBackgroundCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}