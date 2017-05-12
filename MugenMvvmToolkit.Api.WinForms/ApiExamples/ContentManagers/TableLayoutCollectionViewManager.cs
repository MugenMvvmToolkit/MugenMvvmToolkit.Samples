using System.Windows.Forms;
using MugenMvvmToolkit.WinForms.Binding.Infrastructure;

namespace ApiExamples.ContentManagers
{
    public class TableLayoutCollectionViewManager : CollectionViewManagerBase<TableLayoutPanel, Control>
    {
        #region Fields

        public static readonly TableLayoutCollectionViewManager Instance = new TableLayoutCollectionViewManager();

        #endregion

        #region Constructors

        private TableLayoutCollectionViewManager()
        {
        }

        #endregion

        #region Overrides of CollectionViewManagerBase<TableLayoutPanel,Control>

        protected override void Insert(TableLayoutPanel view, int index, Control item)
        {
            view.ColumnCount++;
            view.Controls.Add(item, 0, index);
            view.SetColumn(item, index);
            view.SetRow(item, 0);
        }

        protected override void RemoveAt(TableLayoutPanel view, int index)
        {
            view.Controls.RemoveAt(index);
        }

        protected override void Clear(TableLayoutPanel view)
        {
            view.RowStyles.Clear();
            view.ColumnStyles.Clear();
            view.Controls.Clear();
        }

        #endregion
    }
}