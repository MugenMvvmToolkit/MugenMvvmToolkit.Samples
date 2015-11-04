using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Validation.Portable.Models;
using Validation.Portable.ViewModels;

namespace Validation.Touch.Views
{
    [Register("UserWorkspaceViewController")]
    public class UserWorkspaceViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<UserWorkspaceViewModel>())
            {
                var textField = new UITextField(new CGRect(20, 70, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Name",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.UserEditorViewModel.Name)
                    .TwoWay()
                    .ValidatesOnExceptions()
                    .ValidatesOnNotifyDataErrors();
                View.AddSubview(textField);

                var label = new UILabel(new CGRect(6, 0, 60, 20))
                {
                    Text = "Validating...",
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin,
                    AdjustsFontSizeToFitWidth = true,
                    TextColor = UIColor.Green
                };

                textField = new UITextField(new CGRect(20, 110, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Login",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.UserEditorViewModel.Login)
                    .TwoWay()
                    .WithDelay(400)
                    .ValidatesOnExceptions()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(textField, () => v => v.LeftViewMode)
                    .To(() => (vm, ctx) => vm.UserEditorViewModel.IsLoginValidating ? UITextFieldViewMode.Always : UITextFieldViewMode.Never);
                textField.LeftView = label;
                View.AddSubview(textField);

                textField = new UITextField(new CGRect(20, 150, View.Frame.Width - 40, 30))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Placeholder = "Email",
                    BorderStyle = UITextBorderStyle.RoundedRect
                };
                set.Bind(textField)
                    .To(() => (vm, ctx) => vm.UserEditorViewModel.Email)
                    .TwoWay()
                    .ValidatesOnExceptions()
                    .ValidatesOnNotifyDataErrors();
                View.AddSubview(textField);

                var button = UIButton.FromType(UIButtonType.RoundedRect);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(20, 190, View.Frame.Width / 2 - 20, 30);
                button.SetTitle("Add", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.AddUserCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.RoundedRect);
                button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                button.Frame = new CGRect(View.Frame.Width / 2 - 20, 190, View.Frame.Width / 2 - 20, 30);
                button.SetTitle("Remove", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.RemoveUserCommand);
                View.AddSubview(button);


                var tableView = new UITableView(new CGRect(20, 230, View.Frame.Width - 40, View.Frame.Height - 230))
                {
                    AutoresizingMask = UIViewAutoresizing.FlexibleDimensions,
                };
                tableView.SetCellStyle(UITableViewCellStyle.Default);
                tableView.SetCellBind(cell =>
                {
                    cell.TextLabel.AdjustsFontSizeToFitWidth = true;
                    cell.TextLabel.Bind()
                        .To<UserModel>(() => (m, ctx) => string.Format("Name: {0} Login: {1} Email: {2}", m.Name, m.Login, m.Email))
                        .Build();
                });
                set.Bind(tableView, AttachedMemberConstants.ItemsSource)
                    .To(() => (vm, ctx) => vm.UserGridViewModel.ItemsSource);
                set.Bind(tableView, AttachedMemberConstants.SelectedItem)
                    .To(() => (vm, ctx) => vm.UserGridViewModel.SelectedItem)
                    .TwoWay();
                View.AddSubview(tableView);
            }
        }

        #endregion
    }
}