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
                set.Bind(dialogBtn).To(() => (vm, ctx) => vm.ShowDialogCommand);
                set.Bind(resultBtn).To(() => (vm, ctx) => vm.ShowResultCommand);
                set.Bind(tabsBtn).To(() => (vm, ctx) => vm.ShowTabsCommand);                
            }
        }
    }
}