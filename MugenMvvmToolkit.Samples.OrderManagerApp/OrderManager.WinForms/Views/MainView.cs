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
                   .To(() => m => m.ItemsSource);
                set.Bind(tabControl1, AttachedMembers.TabControl.SelectedItem)
                   .To(() => m => m.SelectedItem)
                   .TwoWay();

                set.Bind(ordersToolStripMenuItem)
                   .To(() => m => m.OpenOrdersCommand);
                set.Bind(productsToolStripMenuItem)
                   .To(() => m => m.OpenProductsCommand);
                set.Bind(exitToolStripMenuItem)
                   .To(() => m => m.CloseCommand);
            }
        }
    }
}