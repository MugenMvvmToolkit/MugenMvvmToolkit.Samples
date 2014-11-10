using System;
using ApiExamples.Models;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.Templates
{
    public class ButtonItemTemplateSelector : DataTemplateSelectorBase<Tuple<string, ViewModelCommandParameter>, StringElement>
    {
        #region Overrides of DataTemplateSelectorBase<Tuple<string,ViewModelCommandParameter>,UIButton>

        protected override StringElement SelectTemplate(Tuple<string, ViewModelCommandParameter> item, object container)
        {
            return new StringElement(string.Empty);
        }

        protected override void Initialize(StringElement template,
            BindingSet<StringElement, Tuple<string, ViewModelCommandParameter>> bindingSet)
        {
            bindingSet.Bind(element => element.Caption).To(tuple => tuple.Item1);
            bindingSet.Bind(AttachedMemberConstants.CommandParameter).To(tuple => tuple.Item2);
            bindingSet.BindFromExpression("Tapped $Relative(UIViewController).DataContext.ShowCommand");
        }

        #endregion
    }
}