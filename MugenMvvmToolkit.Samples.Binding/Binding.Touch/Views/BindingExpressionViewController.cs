using System.Linq;
using Binding.Portable;
using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("BindingExpressionViewController")]
    public class BindingExpressionViewController : MvvmViewController
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

            using (var set = new BindingSet<BindingModeViewModel>())
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
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.Text)
                    .TwoWay();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "LINQ-count of 'a' symbols (Text.Count(x => x == 'a'))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 80, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label)
                    .To(() => (vm, ctx) => vm.Text.OfType<char>().Count(x => x == 'a'));
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 105, View.Frame.Width - 40, 25))
                {
                    Text = "Custom extension method with args (Text.ExtensionMethod(Text.Length))",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 130, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label)
                   .To(() => (vm, ctx) => vm.Text.ExtensionMethod(vm.Text.Length));
                scrollView.AddSubview(label);


                label = new UILabel(new CGRect(20, 155, View.Frame.Width - 40, 25))
                {
                    Text = "LINQ-show second symbol or default (Text.Skip(1).FirstOrDefault())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 175, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label)
                    .To(() => (vm, ctx) => vm.Text.OfType<char>().Skip(1).FirstOrDefault());
                scrollView.AddSubview(label);


                label = new UILabel(new CGRect(20, 200, View.Frame.Width - 40, 25))
                {
                    Text =
                        "Condition expression ($string.IsNullOrEmpty(Text) ? 'String is empty' : 'String is not empty')",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 225, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label)
                    .To(() => (vm, ctx) => string.IsNullOrEmpty(vm.Text) ? "String is empty" : "String is not empty");
                scrollView.AddSubview(label);


                label = new UILabel(new CGRect(20, 250, View.Frame.Width - 40, 25))
                {
                    Text = "Arithmetic expression (Text.Length + 100 + Text.GetHashCode())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 275, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label)
                   .To(() => (vm, ctx) => vm.Text.Length + 100 + vm.Text.GetHashCode());
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 300, View.Frame.Width - 40, 25))
                {
                    Text = "Null conditional expression (Text?.Trim()?.Length ?? -1)",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 325, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text NullableText?.Trim()?.Length ?? -1");
                scrollView.AddSubview(label);


                label = new UILabel(new CGRect(20, 350, View.Frame.Width - 40, 25))
                {
                    Text = "Interpolated string expression ($'{Text} length {Text.Length}')",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 375, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $'{Text} length {Text.Length}'");
                /*set.Bind(label)
                    .To(() => (vm, ctx) => $"{vm.Text} length {vm.Text.Length}");*/ //<-- Visual studio >= 2015
                scrollView.AddSubview(label);
            }
        }

        #endregion
    }
}