using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace ApiExamples.Views
{
    public partial class TabForm : Form
    {
        public TabForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<TabViewModel>())
            {
                set.Bind(addToolStripButton, "Click").To(() => vm => vm.AddCommand);
                set.Bind(insertToolStripButton, "Click").To(() => vm => vm.InsertCommand);
                set.Bind(removeToolStripButton, "Click").To(() => vm => vm.RemoveCommand);
                set.Bind(tabControl, AttachedMemberConstants.ItemsSource).To(() => vm => vm.ItemsSource);
                set.Bind(tabControl, AttachedMemberConstants.SelectedItem).To(() => vm => vm.SelectedItem).TwoWay();
            }
        }
    }
}