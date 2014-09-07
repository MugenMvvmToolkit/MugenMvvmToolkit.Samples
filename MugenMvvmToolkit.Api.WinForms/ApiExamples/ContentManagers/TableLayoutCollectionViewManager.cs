using System.Windows.Forms;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.ContentManagers
{
    public class TableLayoutCollectionViewManager : CollectionViewManagerBase<TableLayoutPanel, Control>
    {
        #region Overrides of CollectionViewManagerBase<TableLayoutPanel,Control>

        /// <summary>
        ///     Inserts an item to the specified index.
        /// </summary>
        protected override void Insert(TableLayoutPanel view, int index, Control item)
        {
            view.ColumnCount++;
            view.Controls.Add(item, 0, index);
            view.SetColumn(item, index);
            view.SetRow(item, 0);
        }

        /// <summary>
        ///     Removes an item.
        /// </summary>
        protected override void RemoveAt(TableLayoutPanel view, int index)
        {
            view.Controls.RemoveAt(index);
        }

        /// <summary>
        ///     Removes all items.
        /// </summary>
        protected override void Clear(TableLayoutPanel view)
        {
            view.RowStyles.Clear();
            view.ColumnStyles.Clear();
            view.Controls.Clear();
        }

        #endregion
    }
}