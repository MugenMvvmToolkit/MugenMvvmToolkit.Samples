using System.Drawing;
using Binding.Portable.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace Binding.Touch.Views
{
    [Register("DynamicObjectViewController")]
    public class DynamicObjectViewController : MvvmViewController
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

            using (var set = new BindingSet<DynamicObjectViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to dynamic property",
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
                    .To("DynamicModel.Text")
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Dynamic value",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 80, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green
                };
                set.Bind(label, field => field.Text).To("DynamicModel.Text");
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}