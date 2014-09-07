using Android.Graphics;
using Android.Views;
using Android.Widget;
using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.TemplateSelectors
{
    public class ListItemTemplateSelector : DataTemplateSelectorBase<ListItemModel, object>
    {
        #region Overrides of DataTemplateSelectorBase<ListItemModel,object>

        protected override object SelectTemplate(ListItemModel item, object container)
        {
            //Return a template id from resources.
            if (item.IsValid)
                return Resource.Layout._ListItemTemplate;

            //Manually create template
            var view = (View) container;
            var template = new TextView(view.Context);
            template.SetTextColor(Color.Red);
            return template;
        }

        protected override void Initialize(object template, BindingSet<object, ListItemModel> bindingSet)
        {
            var textView = template as TextView;
            if (textView != null)
                bindingSet.Bind(textView, view => view.Text).To(model => model.Value);
        }

        #endregion
    }
}