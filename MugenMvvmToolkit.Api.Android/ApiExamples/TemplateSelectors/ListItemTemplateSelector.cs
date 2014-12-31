using ApiExamples.Models;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.TemplateSelectors
{
    public class ListItemTemplateSelector : ResourceDataTemplateSelectorBase<ListItemModel>
    {
        #region Overrides of ResourceDataTemplateSelectorBase<ListItemModel>

        /// <summary>
        ///     Returns the number of types of templates that will be selected by SelectTemplateMethod.
        /// </summary>
        public override int TemplateTypeCount
        {
            get { return 2; }
        }

        /// <summary>
        ///     Returns an app specific template.
        /// </summary>
        /// <param name="item">The data content</param>
        /// <param name="container">The element to which the template will be applied</param>
        /// <returns>
        ///     An app-specific template to apply.
        /// </returns>
        protected override int SelectTemplate(ListItemModel item, object container)
        {
            if (item.IsValid)
                return Resource.Layout._ListItemTemplate;

            return Resource.Layout._ListItemTemplateInvalid;
        }

        #endregion
    }
}