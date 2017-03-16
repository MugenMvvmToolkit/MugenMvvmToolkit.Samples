using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace ApiExamples.Views
{
    [ViewModel(typeof(TabViewModel))]
    public partial class TabForm : Form
    {
        public TabForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<TabViewModel>())
            {
                set.Bind(addToolStripButton).To(() => (vm, ctx) => vm.AddCommand);
                set.Bind(insertToolStripButton).To(() => (vm, ctx) => vm.InsertCommand);
                set.Bind(removeToolStripButton).To(() => (vm, ctx) => vm.RemoveCommand);
                set.Bind(tabControl, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl, AttachedMemberConstants.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
            }
        }
    }
}