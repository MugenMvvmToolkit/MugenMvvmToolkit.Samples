using System.Drawing;
using System.Windows.Forms;
using ApiExamples.ContentManagers;
using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Templates
{
    public class TreeNodeHierarchicalTemplate : DataTemplateSelectorBase<TreeNodeModel, TreeNode>
    {
        #region Fields

        public static readonly TreeNodeHierarchicalTemplate Instance = new TreeNodeHierarchicalTemplate();

        #endregion

        #region Constructors

        private TreeNodeHierarchicalTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<TreeNodeModel,TreeNode>

        protected override TreeNode SelectTemplate(TreeNodeModel item, object container)
        {
            return new TreeNode();
        }

        protected override void Initialize(TreeNode template, BindingSet<TreeNode, TreeNodeModel> bindingSet)
        {
            bindingSet.Bind(() => node => node.Text).To(() => (model, ctx) => model.Name);
            bindingSet.Bind(AttachedMemberConstants.ItemsSource).To(() => (model, ctx) => model.Nodes);
            bindingSet.Bind(() => node => node.ForeColor).To(() => (model, ctx) => model.IsValid ? Color.Green : Color.Red);
            template.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector, this);
            template.SetBindingMemberValue(AttachedMembers.Object.CollectionViewManager, TreeNodeCollectionViewManager.Instance);
        }

        #endregion
    }
}