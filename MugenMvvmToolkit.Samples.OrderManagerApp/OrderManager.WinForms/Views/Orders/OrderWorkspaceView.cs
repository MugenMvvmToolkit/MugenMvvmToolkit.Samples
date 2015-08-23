using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.WinForms.Views.Orders
{
    public partial class OrderWorkspaceView : UserControl
    {
        public OrderWorkspaceView()
        {
            InitializeComponent();
            using (var set = new BindingSet<OrderWorkspaceView, OrderWorkspaceViewModel>(this))
            {
                set.Bind(dataGridView1, AttachedMembers.Object.ItemsSource)
                   .To(() => m => m.GridViewModel.ItemsSource);
                set.Bind(dataGridView1, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => m => m.GridViewModel.SelectedItem);
                set.Bind(toolStripTextBox1)
                   .To(() => m => m.FilterText)
                   .TwoWay();

                set.Bind(saveToolStripButton)
                   .To(() => m => m.SaveChangesCommand);
                set.Bind(addToolStripButton)
                   .To(() => m => m.AddOrderCommand);
                set.Bind(editToolStripButton)
                   .To(() => m => m.EditOrderCommand);
                set.Bind(deleteToolStripButton)
                   .To(() => m => m.RemoveOrderCommand);
                set.Bind(closeToolStripButton)
                   .To(() => m => m.CloseCommand);
            }
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}