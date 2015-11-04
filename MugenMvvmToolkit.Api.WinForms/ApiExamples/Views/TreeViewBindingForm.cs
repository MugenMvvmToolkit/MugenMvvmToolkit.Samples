using System.Windows.Forms;
using ApiExamples.ContentManagers;
using ApiExamples.Templates;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Views
{
    public partial class TreeViewBindingForm : Form
    {
        public TreeViewBindingForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<TreeViewBindingViewModel>())
            {
                set.Bind(addToolStripButton).To(() => (vm, ctx) => vm.AddNodeCommand);
                set.Bind(removeToolStripButton).To(() => (vm, ctx) => vm.RemoveNodeCommand);
                set.Bind(nameTextBox)
                   .To(() => (vm, ctx) => vm.SelectedNode.Name)
                   .TwoWay()
                   .WithFallback("Nothing selected");
                set.Bind(validCheckBox).To(() => (vm, ctx) => vm.SelectedNode.IsValid).TwoWay();
                set.Bind(treeView, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.Nodes);
                set.Bind(treeView, () => view => view.SelectedNode.DataContext())
                   .To(() => (vm, ctx) => vm.SelectedNode)
                   .OneWayToSource();
                treeView.SetBindingMemberValue(AttachedMembers.Object.CollectionViewManager,
                    TreeNodeCollectionViewManager.Instance);
                treeView.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector,
                    TreeNodeHierarchicalTemplate.Instance);
            }
        }
    }
}