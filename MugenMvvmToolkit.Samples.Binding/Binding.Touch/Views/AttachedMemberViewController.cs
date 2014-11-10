using System.Drawing;
using Binding.Portable.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace Binding.Touch.Views
{
    [Register("AttachedMemberViewController")]
    public class AttachedMemberViewController : MvvmViewController
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

            using (var set = new BindingSet<AttachedMemberViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(10);

                var label = new UILabel(new RectangleF(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Current text",
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
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new RectangleF(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Attached auto property",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 80, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font,
                    AccessibilityLabel = "Label_TextExt"
                };
                set.BindFromExpression(label, "TextExt Text");
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 105, View.Frame.Width - 40, 25))
                {
                    Text = "Attached custom property",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new RectangleF(20, 130, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font,
                    AccessibilityLabel = "Label_FormattedText"
                };
                set.BindFromExpression(label, "FormattedText Text");
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}