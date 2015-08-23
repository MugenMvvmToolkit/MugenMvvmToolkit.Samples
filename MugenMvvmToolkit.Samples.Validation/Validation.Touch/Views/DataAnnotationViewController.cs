using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Validation.Portable.ViewModels;

namespace Validation.Touch.Views
{
    [Register("DataAnnotationViewController")]
    public class DataAnnotationViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<DataAnnotationViewModel>())
            {
                var textField = new UITextField(new CGRect(20, 70, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Name",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => model => model.NameInVm)
                    .TwoWay()
                    .ValidatesOnExceptions()
                    .ValidatesOnNotifyDataErrors();
                View.AddSubview(textField);

                var label = new UILabel(new CGRect(20, 110, View.Frame.Width - 100, 30))
                {
                    Text = "Disable description validation",
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin,
                    AdjustsFontSizeToFitWidth = true
                };
                View.AddSubview(label);
                var uiSwitch = new UISwitch(new CGRect(View.Frame.Width - 70, 110, 60, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin
                };
                set.Bind(uiSwitch)
                    .To(() => model => model.DisableDescriptionValidation)
                    .TwoWay();
                View.AddSubview(uiSwitch);


                textField = new UITextField(new CGRect(20, 150, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Description",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => model => model.Description)
                    .TwoWay()
                    .ValidatesOnExceptions()
                    .ValidatesOnNotifyDataErrors();
                View.AddSubview(textField);

                textField = new UITextField(new CGRect(20, 190, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Custom Description error",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => model => model.CustomError)
                    .TwoWay();
                View.AddSubview(textField);


                label = new UILabel(new CGRect(20, 230, View.Frame.Width - 40, 25))
                {
                    Text = "View model is valid",
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin,
                    AdjustsFontSizeToFitWidth = true,
                    TextColor = UIColor.Green
                };
                set.BindFromExpression(label, "Visible IsValid");
                View.AddSubview(label);

                label = new UILabel(new CGRect(20, 230, View.Frame.Width - 40, 25))
                {
                    Text = "View model is not valid",
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    AdjustsFontSizeToFitWidth = true,
                    TextColor = UIColor.Red
                };
                set.BindFromExpression(label, "Visible !IsValid");
                View.AddSubview(label);
            }
        }

        #endregion
    }
}