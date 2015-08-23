using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.WinForms.Views.Orders
{
    public partial class OrderEditorView : UserControl
    {
        public OrderEditorView()
        {
            InitializeComponent();
            using (var set = new BindingSet<OrderEditorView, OrderEditorViewModel>(this))
            {
                set.Bind(dataGridView1, AttachedMembers.Object.ItemsSource)
                   .To(() => m => m.GridViewModel.ItemsSource);
                set.Bind(dataGridView1, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => m => m.GridViewModel.SelectedItem)
                   .TwoWay();
                set.Bind(filterTextBox)
                   .To(() => m => m.FilterText)
                   .TwoWay();

                set.Bind(nameTextBox)
                   .To(() => m => m.Name)
                   .TwoWay()
                   .Validate();
                set.Bind(numberTextBox)
                   .To(() => m => m.Number)
                   .TwoWay()
                   .Validate();
                set.Bind(dateTimePicker1)
                   .To(() => m => m.CreationDate)
                   .TwoWay()
                   .Validate();
            }
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