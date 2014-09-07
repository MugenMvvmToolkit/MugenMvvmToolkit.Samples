using System.Windows.Forms;

namespace Validation.WinForms.Views
{
    public partial class UserWorkspaceView : Form
    {
        public UserWorkspaceView()
        {
            InitializeComponent();
            userDataGridView.AutoGenerateColumns = false;
        }
    }
}