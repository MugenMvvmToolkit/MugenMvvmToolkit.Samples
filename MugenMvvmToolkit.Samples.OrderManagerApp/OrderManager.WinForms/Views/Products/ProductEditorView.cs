using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using OrderManager.Portable.ViewModels.Products;

namespace OrderManager.WinForms.Views.Products
{
    public partial class ProductEditorView : UserControl
    {
        public ProductEditorView()
        {
            InitializeComponent();
            using (var set = new BindingSet<ProductEditorView, ProductEditorViewModel>(this))
            {
                set.Bind(nameTextBox)
                   .To(() => (vm, ctx) => vm.Name)
                   .TwoWay()
                   .Validate();
                set.Bind(priceTextBox)
                   .To(() => (vm, ctx) => vm.Price)
                   .TwoWay()
                   .Validate();
                set.Bind(descTextBox)
                   .To(() => (vm, ctx) => vm.Description)
                   .TwoWay()
                   .Validate();
            }
        }
    }
}