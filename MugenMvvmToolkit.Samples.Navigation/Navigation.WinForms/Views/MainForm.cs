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
                set.Bind(firstViewModelWindowToolStripMenuItem).To(() => m => m.ShowFirstWindowCommand);
                set.Bind(secondViewModelWindowToolStripMenuItem).To(() => m => m.ShowSecondWindowCommand);
                set.Bind(firstViewModelTabToolStripMenuItem).To(() => m => m.ShowFirstTabCommand);
                set.Bind(secondViewModelTabToolStripMenuItem).To(() => m => m.ShowSecondTabCommand);

                set.Bind(tabControl1, AttachedMembers.Object.ItemsSource).To(() => m => m.ItemsSource);
                set.Bind(tabControl1, AttachedMembers.TabControl.SelectedItem).To(() => m => m.SelectedItem).TwoWay();
            }
        }
    }
}