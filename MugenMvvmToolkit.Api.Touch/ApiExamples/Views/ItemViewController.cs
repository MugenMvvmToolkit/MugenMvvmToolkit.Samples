using ApiExamples.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("ItemViewController")]
    public class ItemViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<ItemViewModel>())
            {
                set.BindFromExpression(this, "Title Name + Id");
                var label = new UILabel(new CGRect(0, 70, View.Frame.Width, 30))
                {
                    TextAlignment = UITextAlignment.Center
                };
                set.BindFromExpression(label, "Text Name + Id");
                View.AddSubview(label);

                UIButton button = UIButton.FromType(UIButtonType.RoundedRect);
                button.Frame = new CGRect(0, 100, View.Bounds.Width, 30);
                button.SetTitle("Close view", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}