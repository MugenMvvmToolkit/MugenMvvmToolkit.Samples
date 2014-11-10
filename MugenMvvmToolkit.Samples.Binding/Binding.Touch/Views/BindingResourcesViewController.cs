using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace Binding.Touch.Views
{
    [Register("BindingResourcesViewController")]
    public class BindingResourcesViewController : MvvmViewController
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

            using (var set = new BindingSet())
            {
                UIFont font = UIFont.SystemFontOfSize(10);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Object from resources($obj)",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 25, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $obj");
                scrollView.AddSubview(label);


                label = new UILabel(new RectangleF(20, 50, View.Frame.Width - 40, 25))
                {
                    Text = "Method from resources($Method())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 75, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $Method()");
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 100, View.Frame.Width - 40, 25))
                {
                    Text = "Type from resources($CustomType.StaticMethod())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 125, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $CustomType.StaticMethod()");
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}