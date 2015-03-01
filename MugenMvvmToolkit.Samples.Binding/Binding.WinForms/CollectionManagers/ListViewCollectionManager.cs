using System.Windows.Forms;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace Binding.WinForms.CollectionManagers
{
    public sealed class ListViewCollectionManager : CollectionViewManagerBase<ListView, ListViewItem>
    {
        #region Overrides of CollectionViewManagerBase<ListView,ListViewItem>

        protected override void Insert(ListView view, int index, ListViewItem viewItem)
        {
            view.Items.Insert(index, viewItem);
        }

        protected override void RemoveAt(ListView view, int index)
        {
            view.Items.RemoveAt(index);
        }

        protected override void Clear(ListView view)
        {
            view.Items.Clear();
        }

        #endregion
    }
}