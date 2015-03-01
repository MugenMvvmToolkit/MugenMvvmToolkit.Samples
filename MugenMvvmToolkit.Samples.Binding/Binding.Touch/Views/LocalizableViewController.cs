using Binding.Portable.ViewModels;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("LocalizableViewController")]
    public class LocalizableViewController : MvvmViewController
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

            using (var set = new BindingSet<LocalizableViewModel>())
            {
                UIFont font = UIFont.SystemFontOfSize(10);

                var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $i18n.AddText");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 25, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $i18n.EditText");
                scrollView.AddSubview(label);

                label = new UILabel(new CGRect(20, 50, View.Frame.Width - 40, 25))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    TextColor = UIColor.Green,
                    Font = font
                };
                set.BindFromExpression(label, "Text $i18n.DeleteText");
                scrollView.AddSubview(label);

                var textField = new UITextField(new CGRect(20, 75, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    BorderStyle = UITextBorderStyle.RoundedRect,
                    ShouldChangeCharacters = (field, range, replacementString) => false
                };
                set.Bind(textField, field => field.Text).To(model => model.SelectedCulture);
                scrollView.AddSubview(textField);

                var pickerView = new UIPickerView {ShowSelectionIndicator = true};
                set.Bind(pickerView, AttachedMemberConstants.ItemsSource)
                    .To(model => model.Cultures);
                set.Bind(pickerView, AttachedMemberConstants.SelectedItem)
                    .To(model => model.SelectedCulture)
                    .TwoWay();

                var toolbar = new UIToolbar {BarStyle = UIBarStyle.Black, Translucent = true};
                toolbar.SizeToFit();
                var doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
                    (s, e) => textField.ResignFirstResponder());
                toolbar.SetItems(new[] {doneButton}, true);
                textField.SetInputViewEx(pickerView);
                textField.InputAccessoryView = toolbar;
            }
        }

        #endregion
    }
}