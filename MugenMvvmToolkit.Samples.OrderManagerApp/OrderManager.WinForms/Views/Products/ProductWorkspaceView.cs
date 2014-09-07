using System.Windows.Forms;

namespace OrderManager.WinForms.Views.Products
{
    public partial class ProductWorkspaceView : UserControl
    {
        public ProductWorkspaceView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}