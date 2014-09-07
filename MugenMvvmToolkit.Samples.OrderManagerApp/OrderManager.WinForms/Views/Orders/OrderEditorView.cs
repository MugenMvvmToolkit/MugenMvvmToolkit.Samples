using System.Windows.Forms;
using MugenMvvmToolkit.Binding;

namespace OrderManager.WinForms.Views.Orders
{
    public partial class OrderEditorView : UserControl
    {
        public OrderEditorView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellFormatting += DataGridView1OnCellFormatting;
        }

        private void DataGridView1OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                e.Value = BindingExtensions.GetValueFromPath(
                    dataGridView1.Rows[e.RowIndex].DataBoundItem,
                    dataGridView1.Columns[e.ColumnIndex].DataPropertyName);
        }
    }
}