using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using Validation.Portable.ViewModels;

namespace Validation.WinForms.Views
{
    public partial class UserWorkspaceView : Form
    {
        public UserWorkspaceView()
        {
            InitializeComponent();
            using (var set = new BindingSet<UserWorkspaceViewModel>())
            {
                set.Bind(validatingLabel, () => l => l.Visible)
                   .To(() => m => m.UserEditorViewModel.IsLoginValidating);
                set.Bind(nameTextBox, () => t => t.Text)
                   .To(() => m => m.UserEditorViewModel.Name)
                   .TwoWay()
                   .Validate();
                set.Bind(loginTextBox, () => t => t.Text)
                   .To(() => m => m.UserEditorViewModel.Login)
                   .TwoWay()
                   .Validate()
                   .WithDelay(400);
                set.Bind(emailTextBox, () => t => t.Text)
                   .To(() => m => m.UserEditorViewModel.Email)
                   .TwoWay()
                   .Validate();

                set.Bind(notValidLabel, () => t => t.Visible)
                   .To(() => m => !m.UserEditorViewModel.IsValid);
                set.Bind(validLabel, () => t => t.Visible)
                   .To(() => m => m.UserEditorViewModel.IsValid);

                set.Bind(addButton, "Click")
                   .To(() => m => m.AddUserCommand);
                set.Bind(removeButton, "Click")
                   .To(() => m => m.RemoveUserCommand);

                set.Bind(userDataGridView, AttachedMembers.Object.ItemsSource)
                   .To(() => m => m.UserGridViewModel.ItemsSource);
                set.Bind(userDataGridView, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => m => m.UserGridViewModel.SelectedItem)
                   .TwoWay();
            }
            userDataGridView.AutoGenerateColumns = false;
        }
    }
}