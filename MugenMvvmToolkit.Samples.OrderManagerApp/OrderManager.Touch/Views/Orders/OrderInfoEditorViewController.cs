using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Touch.Views.Orders
{
    [Register("OrderInfoEditorViewController")]
    public class OrderInfoEditorViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            Title = "Main info";

            var scrollView = new UIScrollView(new RectangleF(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new SizeF(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<OrderEditorViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Name",
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
                    .To(model => model.Name)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Number",
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
                    .To(model => model.Number)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);
            }
        }

        #endregion
    }
}