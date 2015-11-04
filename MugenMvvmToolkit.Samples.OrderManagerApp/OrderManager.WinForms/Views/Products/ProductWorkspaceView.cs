using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.WinForms.Views.Products
{
    public partial class ProductWorkspaceView : UserControl
    {
        public ProductWorkspaceView()
        {
            InitializeComponent();
            using (var set = new BindingSet<ProductWorkspaceView, ProductWorkspaceViewModel>(this))
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
                   .To(() => (vm, ctx) => vm.AddProductCommand);
                set.Bind(editToolStripButton)
                   .To(() => (vm, ctx) => vm.EditProductCommand);
                set.Bind(deleteToolStripButton)
                   .To(() => (vm, ctx) => vm.RemoveProductCommand);
                set.Bind(closeToolStripButton)
                   .To(() => (vm, ctx) => vm.CloseCommand);
            }
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}