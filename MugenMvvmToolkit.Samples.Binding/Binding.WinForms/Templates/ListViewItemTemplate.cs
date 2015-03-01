using System.Windows.Forms;
using Binding.Portable.Models;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace Binding.WinForms.Templates
{
    public class ListViewItemTemplate : DataTemplateSelectorBase<CollectionItemModel, ListViewItem>
    {
        #region Overrides of DataTemplateSelectorBase<CollectionItemModel,ListViewItem>

        protected override ListViewItem SelectTemplate(CollectionItemModel item, object container)
        {
            return new ListViewItem();
        }

        protected override void Initialize(ListViewItem template, BindingSet<ListViewItem, CollectionItemModel> set)
        {
            set.BindFromExpression("Text Name + ' ' + Id");
        }

        #endregion
    }
}