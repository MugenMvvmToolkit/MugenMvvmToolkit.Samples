using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using OrderManager.Portable.ViewModels;
using OrderManager.WinForms.Templates;

namespace OrderManager.WinForms.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            using (var set = new BindingSet<MainView, MainViewModel>(this))
            {
                tabControl1.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector,
                    ViewModelTabDataTemplate.Instance);
                set.Bind(tabControl1, AttachedMembers.Object.ItemsSource)
                   .To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl1, AttachedMembers.TabControl.SelectedItem)
                   .To(() => (vm, ctx) => vm.SelectedItem)
                   .TwoWay();

                set.Bind(ordersToolStripMenuItem)
                   .To(() => (vm, ctx) => vm.OpenOrdersCommand);
                set.Bind(productsToolStripMenuItem)
                   .To(() => (vm, ctx) => vm.OpenProductsCommand);
                set.Bind(exitToolStripMenuItem)
                   .To(() => (vm, ctx) => vm.CloseCommand);
            }
        }
    }
}