using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;
using UIKit;

namespace ApiExamples.Templates
{
    public class TabTemplateSelector : DataTemplateSelectorBase<ItemViewModel, UIResponder>
    {
        #region Fields

        public static readonly TabTemplateSelector Instance = new TabTemplateSelector();

        #endregion

        #region Constructors

        private TabTemplateSelector()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<ItemViewModel,UIResponder>

        protected override UIResponder SelectTemplate(ItemViewModel item, object container)
        {
            if (item.Id % 2 == 0)
                return new UIView { BackgroundColor = UIColor.Green };
            return new UIView { BackgroundColor = UIColor.Red };
        }

        protected override void Initialize(UIResponder template, BindingSet<UIResponder, ItemViewModel> bindingSet)
        {
        }

        #endregion
    }
}