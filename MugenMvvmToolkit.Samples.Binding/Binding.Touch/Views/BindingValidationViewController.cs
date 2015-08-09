using System;
using System.Linq;
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
    [Register("BindingValidationViewController")]
    public class BindingValidationViewController : MvvmViewController
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

            using (var set = new BindingSet<BindingValidationViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'Property' with 'ValidatesOnNotifyDataErrors=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                var textField = new UITextField(new CGRect(20, 25, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect,
                };
                set.Bind(textField, () => field => field.Text)
                    .To(() => model => model.Property)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 55, View.Frame.Width - 40, 25))
                {
                    Text =
                        "Binding to 'PropertyWithException' with 'ValidatesOnNotifyDataErrors=True, ValidatesOnExceptions=False'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 80, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, () => field => field.Text)
                    .To(() => model => model.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                scrollView.AddSubview(textField);

                label = new UILabel(new CGRect(20, 110, View.Frame.Width - 40, 25))
                {
                    Text =
                        "Binding to 'PropertyWithException' with 'ValidatesOnNotifyDataErrors=False, ValidatesOnExceptions=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 135, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, () => field => field.Text)
                    .To(() => model => model.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnExceptions();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 165, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'PropertyWithException' with 'Validate=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 190, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, () => field => field.Text)
                    .To(() => model => model.PropertyWithException)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);


                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 220, View.Frame.Width - 40, 30);
                button.SetTitle("Set error(PropertyWithException)", UIControlState.Normal);
                set.Bind(button, "Click").To(() => model => model.AddErrorCommand);
                scrollView.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 250, View.Frame.Width - 40, 30);
                button.SetTitle("Clear error(PropertyWithException)", UIControlState.Normal);
                set.Bind(button, "Click").To(() => model => model.RemoveErrorCommand);
                scrollView.AddSubview(button);

                label = new UILabel(new CGRect(20, 280, View.Frame.Width - 40, 25))
                {
                    Text = "Validation summary",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                set.Bind(label, "Visible")
                    .To(() => vm => BindingSyntaxEx.GetErrors().Any());
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 305, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font,
                    Lines = 0,
                    TextColor = UIColor.Red,
                    AdjustsFontSizeToFitWidth = true
                };
                set.Bind(label, "TextSizeToFit").To(() => vm => string.Join(Environment.NewLine, BindingSyntaxEx.GetErrors()));
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}