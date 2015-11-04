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
                   .To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
                set.Bind(dataGridView1, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => (vm, ctx) => vm.GridViewModel.SelectedItem)
                   .TwoWay();
                set.Bind(toolStripTextBox1)
                   .To(() => (vm, ctx) => vm.FilterText)
                   .TwoWay();

                set.Bind(saveToolStripButton)
                   .To(() => (vm, ctx) => vm.SaveChangesCommand);
                set.Bind(addToolStripButton)
                   .To(() => (vm, ctx) => vm.AddOrderCommand);
                set.Bind(editToolStripButton)
                   .To(() => (vm, ctx) => vm.EditOrderCommand);
                set.Bind(deleteToolStripButton)
                   .To(() => (vm, ctx) => vm.RemoveOrderCommand);
                set.Bind(closeToolStripButton)
                   .To(() => (vm, ctx) => vm.CloseCommand);
            }
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}