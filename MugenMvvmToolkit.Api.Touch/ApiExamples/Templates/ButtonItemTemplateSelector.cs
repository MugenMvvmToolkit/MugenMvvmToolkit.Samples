using System;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Binding;
using UIKit;

namespace ApiExamples.Templates
{
    public class ButtonItemTemplateSelector : DataTemplateSelectorBase<Tuple<string, ViewModelCommandParameter>, StringElement>
    {
        #region Fields

        public static readonly ButtonItemTemplateSelector Instance = new ButtonItemTemplateSelector();

        #endregion

        #region Constructors

        private ButtonItemTemplateSelector()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<Tuple<string,ViewModelCommandParameter>,UIButton>

        protected override StringElement SelectTemplate(Tuple<string, ViewModelCommandParameter> item, object container)
        {
            return new StringElement(string.Empty);
        }

        protected override void Initialize(StringElement template,
            BindingSet<StringElement, Tuple<string, ViewModelCommandParameter>> bindingSet)
        {
            bindingSet.Bind(() => element => element.Caption).To(() => tuple => tuple.Item1);
            bindingSet.Bind(AttachedMembers.StringElement.TappedEvent)
                .To(() => model => BindingSyntaxEx.Relative<UIViewController>().DataContext<MainViewModel>().ShowCommand)
                .OneTime()
                .WithCommandParameter(() => tuple => tuple.Item2);
        }

        #endregion
    }
}