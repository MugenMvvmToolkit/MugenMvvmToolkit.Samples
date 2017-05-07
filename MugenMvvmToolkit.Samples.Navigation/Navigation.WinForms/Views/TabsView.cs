using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class TabsView : Form
    {
        public TabsView()
        {
            InitializeComponent();
            using (var set = new BindingSet<TabsViewModel>())
            {
                set.Bind(addTabMenuItem).To(() => (vm, ctx) => vm.AddTabCommand);
                set.Bind(addTabPresenterMenuItem).To(() => (vm, ctx) => vm.AddTabPresenterCommand);
                
                set.Bind(tabControl1, AttachedMembers.Object.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl1, AttachedMembers.TabControl.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
            }
        }
    }
}