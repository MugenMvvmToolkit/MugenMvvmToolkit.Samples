using System;
using Binding.Portable.ViewModels;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Binding;
using UIKit;

namespace Binding.Touch.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, Type>, StringElement>
    {
        #region Fields

        public static readonly ButtonItemTemplate Instance = new ButtonItemTemplate();

        #endregion

        #region Constructors

        private ButtonItemTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<Tuple<string,ViewModelCommandParameter>,UIButton>

        protected override StringElement SelectTemplate(Tuple<string, Type> item, object container)
        {
            return new StringElement(string.Empty);
        }

        protected override void Initialize(StringElement template,
            BindingSet<StringElement, Tuple<string, Type>> bindingSet)
        {
            bindingSet.Bind(() => e => e.Caption).To(() => t => t.Item1).OneTime();
            bindingSet.Bind(AttachedMembers.StringElement.TappedEvent)
                .To(() => vm => BindingSyntaxEx.Relative<UIViewController>().DataContext<MainViewModel>().ShowCommand)
                .OneTime()
                .WithCommandParameter(() => tuple => tuple.Item2);
        }

        #endregion
    }
}