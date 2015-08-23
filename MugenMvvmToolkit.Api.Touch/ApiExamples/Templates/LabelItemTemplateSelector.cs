using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;
using UIKit;

namespace ApiExamples.Templates
{
    public class LabelItemTemplateSelector : DataTemplateSelectorBase<ItemViewModel, UILabel>
    {
        #region Fields

        public static readonly LabelItemTemplateSelector Instance = new LabelItemTemplateSelector();

        #endregion

        #region Constructors

        private LabelItemTemplateSelector()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<ItemViewModel,UITextField>

        protected override UILabel SelectTemplate(ItemViewModel item, object container)
        {
            if (item == null)
                return null;
            return new UILabel { TextAlignment = UITextAlignment.Center };
        }

        protected override void Initialize(UILabel template, BindingSet<UILabel, ItemViewModel> bindingSet)
        {
            bindingSet.Bind().To(() => m => "Item " + m.Id);
        }

        #endregion
    }
}