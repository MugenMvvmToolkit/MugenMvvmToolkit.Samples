using System.Drawing;
using Binding.Portable.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

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

            var scrollView = new UIScrollView(new RectangleF(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new SizeF(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<BindingValidationViewModel>())
            {
                var font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'Property' with 'ValidatesOnNotifyDataErrors=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                var textField = new UITextField(new RectangleF(20, 25, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect,
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.Property)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'PropertyWithException' with 'ValidatesOnNotifyDataErrors=True, ValidatesOnExceptions=False'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new RectangleF(20, 80, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                scrollView.AddSubview(textField);

                label = new UILabel(new RectangleF(20, 110, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'PropertyWithException' with 'ValidatesOnNotifyDataErrors=False, ValidatesOnExceptions=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new RectangleF(20, 135, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnExceptions();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 165, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to 'PropertyWithException' with 'Validate=True'",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new RectangleF(20, 190, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.PropertyWithException)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);


                UIButton button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new RectangleF(20, 220, View.Frame.Width - 40, 30);
                button.SetTitle("Set error(PropertyWithException)", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.AddErrorCommand);
                scrollView.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new RectangleF(20, 250, View.Frame.Width - 40, 30);
                button.SetTitle("Clear error(PropertyWithException)", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.RemoveErrorCommand);
                scrollView.AddSubview(button);

                label = new UILabel(new RectangleF(20, 280, View.Frame.Width - 40, 25))
                {
                    Text = "Validation summary",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                set.BindFromExpression(label, "Visible $GetErrors().Any()");
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 305, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font,
                    Lines = 0,
                    TextColor = UIColor.Red,
                    AdjustsFontSizeToFitWidth = true
                };
                set.BindFromExpression(label, "TextSizeToFit $string.Join($Environment.NewLine, $GetErrors())");
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}