using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.WinForms.Binding;
using OrderManager.Portable.ViewModels;
using OrderManager.WinForms.Templates;

namespace OrderManager.WinForms.Views
{
    public partial class EditorWrapperView : Form
    {
        public EditorWrapperView()
        {
            InitializeComponent();
            using (var set = new BindingSet<EditorWrapperView, EditorWrapperViewModel<IEditableViewModel>>(this))
            {
                this.SetBindingMemberValue(AttachedMembers.Control.ContentViewManager, WrapperContentManager.Instance);
                set.Bind(() => v => v.Text)
                   .To(() => (vm, ctx) => vm.DisplayName);
                set.Bind(AttachedMembersEx.Control.IsBusy)
                   .To(() => (vm, ctx) => vm.IsBusy);
                set.Bind(AttachedMembersEx.Control.BusyMessage)
                   .To(() => (vm, ctx) => vm.BusyMessage);
                set.Bind(AttachedMembers.Control.Content)
                   .To(() => (vm, ctx) => vm.ViewModel);

                set.Bind(saveButton)
                   .To(() => (vm, ctx) => vm.ApplyCommand);
                set.Bind(closeButton)
                   .To(() => (vm, ctx) => vm.CloseCommand);
            }
        }

        public void SetContent(Control control)
        {
            if (control == null)
            {
                Controls.Clear();
                return;
            }
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            Width = control.Width + 20;
            Height += control.Height;
            Controls.Add(control);
            control.Top = 4;
        }
    }
}