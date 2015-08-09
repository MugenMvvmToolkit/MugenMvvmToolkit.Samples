using System.Windows.Forms;
using MugenMvvmToolkit.WinForms.Binding.Infrastructure;

namespace ApiExamples.ContentManagers
{
    public class TreeNodeCollectionViewManager : CollectionViewManagerBase<object, TreeNode>
    {
        #region Fields

        public static readonly TreeNodeCollectionViewManager Instance = new TreeNodeCollectionViewManager();

        #endregion

        #region Constructors

        private TreeNodeCollectionViewManager()
        {
        }

        #endregion

        #region Overrides of CollectionViewManagerBase<object,TreeNode>

        protected override void Insert(object view, int index, TreeNode item)
        {
            var treeNode = view as TreeNode;
            if (treeNode == null)
                ((TreeView)view).Nodes.Insert(index, item);
            else
                treeNode.Nodes.Insert(index, item);
        }

        protected override void RemoveAt(object view, int index)
        {
            var treeNode = view as TreeNode;
            if (treeNode == null)
                ((TreeView)view).Nodes.RemoveAt(index);
            else
                treeNode.Nodes.RemoveAt(index);
        }

        protected override void Clear(object view)
        {
            var treeNode = view as TreeNode;
            if (treeNode == null)
                ((TreeView)view).Nodes.Clear();
            else
                treeNode.Nodes.Clear();
        }

        #endregion
    }
}