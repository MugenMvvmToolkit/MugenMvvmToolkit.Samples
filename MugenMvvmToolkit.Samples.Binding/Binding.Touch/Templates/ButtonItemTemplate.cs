using System;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace Binding.Touch.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, Type>, StringElement>
    {
        #region Overrides of DataTemplateSelectorBase<Tuple<string,ViewModelCommandParameter>,UIButton>

        protected override StringElement SelectTemplate(Tuple<string, Type> item, object container)
        {
            return new StringElement(string.Empty);
        }

        protected override void Initialize(StringElement template,
            BindingSet<StringElement, Tuple<string, Type>> bindingSet)
        {
            bindingSet.Bind(element => element.Caption).To(tuple => tuple.Item1);
            bindingSet.Bind(AttachedMemberConstants.CommandParameter).To(tuple => tuple.Item2);
            bindingSet.BindFromExpression("Tapped $Relative(UIViewController).DataContext.ShowCommand");
        }

        #endregion
    }
}