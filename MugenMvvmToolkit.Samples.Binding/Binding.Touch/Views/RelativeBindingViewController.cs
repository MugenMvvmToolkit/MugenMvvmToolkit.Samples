using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("RelativeBindingViewController")]
    public class RelativeBindingViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Title";
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet())
            {
                var slider = new UISlider(new CGRect(20, 65, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    AccessibilityLabel = "slider",
                    MinValue = 0,
                    MaxValue = 100,
                    Value = 50,
                };
                View.AddSubview(slider);

                var textField = new UITextField(new CGRect(20, 95, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect,
                };

                set.Bind(textField)
                    .To<object>(() => o => BindingSyntaxEx.Element<UISlider>("slider").Value)
                    .TwoWay();
                View.AddSubview(textField);

                var label = new UILabel(new CGRect(20, 125, View.Frame.Width - 100, 25))
                {
                    Text = "Current title",
                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin,
                    AdjustsFontSizeToFitWidth = true,
                    Font = UIFont.SystemFontOfSize(12)
                };
                View.AddSubview(label);

                textField = new UITextField(new CGRect(20, 150, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To<object>(() => o => BindingSyntaxEx.Relative<UIViewController>().Title)
                    .TwoWay();
                View.AddSubview(textField);


                label = new UILabel(new CGRect(20, 180, View.Frame.Width - 100, 25))
                {
                    Text = "Self binding to width",
                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin,
                    AdjustsFontSizeToFitWidth = true,
                    Font = UIFont.SystemFontOfSize(12)
                };
                View.AddSubview(label);

                label = new UILabel(new CGRect(20, 205, 280, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green
                };
                set.Bind(label)
                    .ToSelf(() => l => l.Frame.Width);
                View.AddSubview(label);


                label = new UILabel(new CGRect(20, 235, View.Frame.Width - 100, 25))
                {
                    Text = "Root element:",
                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin,
                    AdjustsFontSizeToFitWidth = true,
                    Font = UIFont.SystemFontOfSize(12)
                };
                View.AddSubview(label);

                label = new UILabel(new CGRect(20, 260, 280, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green
                };
                set.Bind(label)
                    .To<object>(() => o => BindingSyntaxEx.Root<object>());
                View.AddSubview(label);
            }
        }

        #endregion
    }
}