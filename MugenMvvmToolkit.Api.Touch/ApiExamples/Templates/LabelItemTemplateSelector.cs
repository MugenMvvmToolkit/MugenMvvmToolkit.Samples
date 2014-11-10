using ApiExamples.ViewModels;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.Templates
{
    public class LabelItemTemplateSelector : DataTemplateSelectorBase<ItemViewModel, UILabel>
    {
        #region Overrides of DataTemplateSelectorBase<ItemViewModel,UITextField>

        protected override UILabel SelectTemplate(ItemViewModel item, object container)
        {
            if (item == null)
                return null;
            return new UILabel { TextAlignment = UITextAlignment.Center };
        }

        protected override void Initialize(UILabel template, BindingSet<UILabel, ItemViewModel> bindingSet)
        {
            bindingSet.BindFromExpression("Text 'Item' + Id");
        }

        #endregion
    }
}