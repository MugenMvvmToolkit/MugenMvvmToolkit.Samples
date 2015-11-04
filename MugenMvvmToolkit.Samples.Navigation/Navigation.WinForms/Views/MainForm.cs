using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(firstViewModelWindowToolStripMenuItem).To(() => (vm, ctx) => vm.ShowFirstWindowCommand);
                set.Bind(secondViewModelWindowToolStripMenuItem).To(() => (vm, ctx) => vm.ShowSecondWindowCommand);
                set.Bind(firstViewModelTabToolStripMenuItem).To(() => (vm, ctx) => vm.ShowFirstTabCommand);
                set.Bind(secondViewModelTabToolStripMenuItem).To(() => (vm, ctx) => vm.ShowSecondTabCommand);

                set.Bind(tabControl1, AttachedMembers.Object.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl1, AttachedMembers.TabControl.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
            }
        }
    }
}