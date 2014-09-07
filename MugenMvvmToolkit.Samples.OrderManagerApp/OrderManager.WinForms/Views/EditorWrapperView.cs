using System.Windows.Forms;

namespace OrderManager.WinForms.Views
{
    public partial class EditorWrapperView : Form
    {
        public EditorWrapperView()
        {
            InitializeComponent();
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