using ApiExamples.Models;
using MugenMvvmToolkit.Android.Binding.Infrastructure;

namespace ApiExamples.TemplateSelectors
{
    public class ListItemTemplateSelector : ResourceDataTemplateSelectorBase<ListItemModel>
    {
        #region Overrides of ResourceDataTemplateSelectorBase<ListItemModel>

        public override int TemplateTypeCount => 2;

        protected override int SelectTemplate(ListItemModel item, object container)
        {
            if (item.IsValid)
                return Resource.Layout._ListItemTemplate;

            return Resource.Layout._ListItemTemplateInvalid;
        }

        #endregion
    }
}