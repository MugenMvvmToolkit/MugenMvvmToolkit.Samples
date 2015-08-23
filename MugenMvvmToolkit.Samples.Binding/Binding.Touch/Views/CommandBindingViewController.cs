using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("CommandBindingViewController")]
    public class CommandBindingViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            var scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new CGSize(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<CommandBindingViewModel>())
            {
                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 100, 30))
                {
                    Text = "Can execute command",
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin,
                    AdjustsFontSizeToFitWidth = true
                };
                scrollView.AddSubview(label);
                var uiSwitch = new UISwitch(new CGRect(View.Frame.Width - 70, 0, 60, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin
                };
                set.Bind(uiSwitch)
                    .To(() => model => model.CanExecuteCommand)
                    .TwoWay();
                scrollView.AddSubview(uiSwitch);

                UIFont font = UIFont.SystemFontOfSize(9);
                label = new UILabel(new CGRect(20, 30, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to command",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 55, View.Frame.Width - 40, 30);
                button.SetTitle("Click", UIControlState.Normal);
                set.Bind(button).To(() => model => model.Command).WithCommandParameter("1");
                scrollView.AddSubview(button);


                label = new UILabel(new CGRect(20, 85, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to command(ToggleEnabledState = false)",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 110, View.Frame.Width - 40, 30);
                button.SetTitle("Click", UIControlState.Normal);
                set.Bind(button).To(() => model => model.Command).ToggleEnabledState(false).WithCommandParameter("2");
                scrollView.AddSubview(button);

                label = new UILabel(new CGRect(20, 140, View.Frame.Width - 40, 25))
                {
                    Text = "Method without parameters (EventMethod(null))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                var textField = new UITextField(new CGRect(20, 165, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(null));
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 195, View.Frame.Width - 40, 25))
                {
                    Text = "Method with parameter (EventMethod($self.Text))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 220, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(BindingSyntaxEx.Self<UITextField>().Text));
                scrollView.AddSubview(textField);

                label = new UILabel(new CGRect(20, 250, View.Frame.Width - 40, 25))
                {
                    Text = "Method with event args parameter (EventMethod($args))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 275, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(BindingSyntaxEx.EventArgs<object>()));
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 305, View.Frame.Width - 40, 25))
                {
                    Text = "Method with several parameters (EventMethodMultiParams($self.Text, $args))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 330, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, "TextChanged")
                    .ToAction(() => vm => vm.EventMethodMultiParams(BindingSyntaxEx.Self<UITextField>().Text, BindingSyntaxEx.EventArgs<object>()));
                scrollView.AddSubview(textField);
            }
        }

        #endregion
    }
}