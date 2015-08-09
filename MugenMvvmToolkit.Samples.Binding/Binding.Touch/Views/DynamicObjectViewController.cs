using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

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

            var scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new CGSize(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<DynamicObjectViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Binding to dynamic property",
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
                    .To("DynamicModel.Text")
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Dynamic value",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 80, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green
                };
                set.Bind(label, () => field => field.Text).To("DynamicModel.Text");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 105, View.Frame.Width - 40, 25))
                {
                    Text = "Dynamic method call",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 130, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    AdjustsFontSizeToFitWidth = true
                };
                set.BindFromExpression(label, "Text DynamicModel.DynamicMethod(DynamicModel.Text)");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 155, View.Frame.Width - 40, 25))
                {
                    Text = "Dynamic index call",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 180, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    AdjustsFontSizeToFitWidth = true
                };
                set.BindFromExpression(label, "Text DynamicModel[DynamicModel.Text]");
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}