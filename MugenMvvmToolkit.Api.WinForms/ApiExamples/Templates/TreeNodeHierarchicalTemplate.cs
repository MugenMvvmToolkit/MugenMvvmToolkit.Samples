using System.Windows.Forms;
using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.Templates
{
    public class TreeNodeHierarchicalTemplate : DataTemplateSelectorBase<TreeNodeModel, TreeNode>
    {
        #region Overrides of DataTemplateSelectorBase<TreeNodeModel,TreeNode>

        protected override TreeNode SelectTemplate(TreeNodeModel item, object container)
        {
            return new TreeNode();
        }

        protected override void Initialize(TreeNode template, BindingSet<TreeNode, TreeNodeModel> bindingSet)
        {
            bindingSet.Bind(node => node.Text).To(model => model.Name);
            bindingSet.Bind(AttachedMemberConstants.ItemsSource).To(model => model.Nodes);
            bindingSet.BindFromExpression("ForeColor IsValid ? $Color.Green : $Color.Red");
            bindingSet.BindFromExpression("ItemTemplate $treeNodeTemplate");
            bindingSet.BindFromExpression("CollectionViewManager $treeNodeCollectionViewManager");            
        }

        #endregion
    }
}