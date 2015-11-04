using System.Windows.Forms;
using ApiExamples.Templates;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Views
{
    [ViewModel(typeof(TabViewModel), Constants.TabViewItemTeplate)]
    public partial class TabFormItemTemplate : Form
    {
        public TabFormItemTemplate()
        {
            InitializeComponent();

            using (var set = new BindingSet<TabViewModel>())
            {
                set.Bind(addToolStripButton).To(() => (vm, ctx) => vm.AddCommand);
                set.Bind(insertToolStripButton).To(() => (vm, ctx) => vm.InsertCommand);
                set.Bind(removeToolStripButton).To(() => (vm, ctx) => vm.RemoveCommand);
                set.Bind(tabControl, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl, AttachedMemberConstants.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
                tabControl.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector, TabItemTemplate.Instance);
            }
        }
    }
}