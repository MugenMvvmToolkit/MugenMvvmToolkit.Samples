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
                   .To(() => m => m.DisplayName);
                set.Bind(AttachedMembersEx.Control.IsBusy)
                   .To(() => m => m.IsBusy);
                set.Bind(AttachedMembersEx.Control.BusyMessage)
                   .To(() => m => m.BusyMessage);
                set.Bind(AttachedMembers.Control.Content)
                   .To(() => m => m.ViewModel);

                set.Bind(saveButton)
                   .To(() => m => m.ApplyCommand);
                set.Bind(closeButton)
                   .To(() => m => m.CloseCommand);
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