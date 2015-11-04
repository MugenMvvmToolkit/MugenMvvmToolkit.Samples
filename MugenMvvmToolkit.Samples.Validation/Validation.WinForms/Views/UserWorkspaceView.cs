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
                   .To(() => (vm, ctx) => vm.UserEditorViewModel.IsLoginValidating);
                set.Bind(nameTextBox)
                   .To(() => (vm, ctx) => vm.UserEditorViewModel.Name)
                   .TwoWay()
                   .Validate();
                set.Bind(loginTextBox)
                   .To(() => (vm, ctx) => vm.UserEditorViewModel.Login)
                   .TwoWay()
                   .Validate()
                   .WithDelay(400);
                set.Bind(emailTextBox)
                   .To(() => (vm, ctx) => vm.UserEditorViewModel.Email)
                   .TwoWay()
                   .Validate();

                set.Bind(notValidLabel, () => t => t.Visible)
                   .To(() => (vm, ctx) => !vm.UserEditorViewModel.IsValid);
                set.Bind(validLabel, () => t => t.Visible)
                   .To(() => (vm, ctx) => vm.UserEditorViewModel.IsValid);

                set.Bind(addButton)
                   .To(() => (vm, ctx) => vm.AddUserCommand);
                set.Bind(removeButton)
                   .To(() => (vm, ctx) => vm.RemoveUserCommand);

                set.Bind(userDataGridView, AttachedMembers.Object.ItemsSource)
                   .To(() => (vm, ctx) => vm.UserGridViewModel.ItemsSource);
                set.Bind(userDataGridView, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => (vm, ctx) => vm.UserGridViewModel.SelectedItem)
                   .TwoWay();
            }
            userDataGridView.AutoGenerateColumns = false;
        }
    }
}