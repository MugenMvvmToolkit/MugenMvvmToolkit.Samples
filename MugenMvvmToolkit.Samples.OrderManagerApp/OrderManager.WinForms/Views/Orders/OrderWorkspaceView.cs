using System.Windows.Forms;

namespace OrderManager.WinForms.Views.Orders
{
    public partial class OrderWorkspaceView : UserControl
    {
        public OrderWorkspaceView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}