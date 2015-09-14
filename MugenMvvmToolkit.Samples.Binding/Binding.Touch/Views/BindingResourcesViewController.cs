using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

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

            var scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new CGSize(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            using (var set = new BindingSet<BindingResourcesViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(10);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    Text = "Object from resources($obj)",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 25, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.Bind(label).To(() => vm => BindingSyntaxEx.Resource<object>("obj"));
                scrollView.AddSubview(label);


                label = new UILabel(new CGRect(20, 50, View.Frame.Width - 40, 25))
                {
                    Text = "Method from resources($Method())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 75, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $Method()");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 100, View.Frame.Width - 40, 25))
                {
                    Text = "Type from resources($CustomType.StaticMethod())",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Font = font
                };
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 125, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $CustomType.StaticMethod()");
                scrollView.AddSubview(label);


                var btn = UIButton.FromType(UIButtonType.System);
                btn.Frame = new CGRect(20, 150, View.Frame.Width - 40, 25);
                btn.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                btn.SetTitle("Update resource", UIControlState.Normal);
                set.Bind(btn).To(() => m => m.UpdateResourceCommand);
                scrollView.AddSubview(btn);
            }
        }

        #endregion
    }
}