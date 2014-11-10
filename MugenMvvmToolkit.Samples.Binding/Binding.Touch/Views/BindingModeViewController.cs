using System.Drawing;
using Binding.Portable.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace Binding.Touch.Views
{
    [Register("BindingModeViewController")]
    public class BindingModeViewController : MvvmViewController
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

            using (var set = new BindingSet<BindingModeViewModel>())
            {
                var font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "One time binding",
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
                    .To(model => model.Text)
                    .OneTime();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "One way binding",
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
                    .To(model => model.Text)
                    .OneWay();
                scrollView.AddSubview(textField);

                label = new UILabel(new RectangleF(20, 110, View.Frame.Width - 40, 25))
                {
                    Text = "One way binding with target delay 1000",
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
                   .To(model => model.Text)
                   .OneWay()
                   .WithDelay(1000, true);
                scrollView.AddSubview(textField);

                label = new UILabel(new RectangleF(20, 165, View.Frame.Width - 40, 25))
                {
                    Text = "One way to source binding",
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
                    .To(model => model.Text)
                    .OneWayToSource();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 220, View.Frame.Width - 40, 25))
                {
                    Text = "Two way binding",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new RectangleF(20, 245, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.Text)
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 275, View.Frame.Width - 40, 25))
                {
                    Text = "Two way binding with source delay 1000",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new RectangleF(20, 300, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField, field => field.Text)
                    .To(model => model.Text)
                    .TwoWay()
                    .WithDelay(1000);
                scrollView.AddSubview(textField);
            }
        }

        #endregion
    }
}