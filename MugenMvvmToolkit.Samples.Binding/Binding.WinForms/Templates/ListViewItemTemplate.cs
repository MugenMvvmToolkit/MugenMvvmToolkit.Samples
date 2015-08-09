using System.Windows.Forms;
using Binding.Portable.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace Binding.WinForms.Templates
{
    public class ListViewItemTemplate : DataTemplateSelectorBase<CollectionItemModel, ListViewItem>
    {
        #region Fields

        public static readonly ListViewItemTemplate Instance = new ListViewItemTemplate();

        #endregion

        #region Constructors

        private ListViewItemTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<CollectionItemModel,ListViewItem>

        protected override ListViewItem SelectTemplate(CollectionItemModel item, object container)
        {
            return new ListViewItem();
        }

        protected override void Initialize(ListViewItem template, BindingSet<ListViewItem, CollectionItemModel> set)
        {
            set.Bind(() => item => item.Text).To(() => model => model.Name + " " + model.Id);
        }

        #endregion
    }
}