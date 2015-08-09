using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

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

            var scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new CGSize(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<AttachedMemberViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(10);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Current text",
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
                    .To(() => model => model.Text)
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Attached auto property",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 80, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font,
                    AccessibilityLabel = "Label_TextExt"
                };
                set.BindFromExpression(label, "TextExt Text");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 105, View.Frame.Width - 40, 25))
                {
                    Text = "Attached custom property",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 130, View.Frame.Width - 40, 25))
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