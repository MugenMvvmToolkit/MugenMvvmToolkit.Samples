using System.Drawing;
using ApiExamples.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

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
                var label = new UILabel(new RectangleF(0, 70, View.Frame.Width, 30))
                {
                    TextAlignment = UITextAlignment.Center
                };
                set.BindFromExpression(label, "Text Name + Id");
                View.AddSubview(label);

                UIButton button = UIButton.FromType(UIButtonType.RoundedRect);
                button.Frame = new RectangleF(0, 100, View.Bounds.Width, 30);
                button.SetTitle("Close view", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}