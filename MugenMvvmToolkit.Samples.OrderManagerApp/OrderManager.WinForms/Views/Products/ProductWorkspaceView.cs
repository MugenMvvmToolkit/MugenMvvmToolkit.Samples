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
                   .To(() => m => m.GridViewModel.ItemsSource);
                set.Bind(dataGridView1, AttachedMembers.DataGridView.SelectedItem)
                   .To(() => m => m.GridViewModel.SelectedItem);
                set.Bind(toolStripTextBox1, () => box => box.Text)
                   .To(() => m => m.FilterText)
                   .TwoWay();

                set.Bind(saveToolStripButton, "Click")
                   .To(() => m => m.SaveChangesCommand);
                set.Bind(addToolStripButton, "Click")
                   .To(() => m => m.AddProductCommand);
                set.Bind(editToolStripButton, "Click")
                   .To(() => m => m.EditProductCommand);
                set.Bind(deleteToolStripButton, "Click")
                   .To(() => m => m.RemoveProductCommand);
                set.Bind(closeToolStripButton, "Click")
                   .To(() => m => m.CloseCommand);
            }
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}