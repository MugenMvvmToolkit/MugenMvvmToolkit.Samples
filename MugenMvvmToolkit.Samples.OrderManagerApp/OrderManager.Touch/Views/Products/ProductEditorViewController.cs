using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.Touch.Views.Products
{
    [Register("ProductEditorViewController")]
    public class ProductEditorViewController : MvvmViewController
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

            using (var set = new BindingSet<ProductEditorViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(12);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Name",
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
                    .To(() => (vm, ctx) => vm.Name)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);


                label = new UILabel(new CGRect(20, 55, View.Frame.Width - 40, 25))
                {
                    Text = "Price",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 80, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.Price)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);

                label = new UILabel(new CGRect(20, 110, View.Frame.Width - 40, 25))
                {
                    Text = "Description",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                textField = new UITextField(new CGRect(20, 135, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.Description)
                    .TwoWay()
                    .Validate();
                scrollView.AddSubview(textField);
            }
        }

        #endregion
    }
}