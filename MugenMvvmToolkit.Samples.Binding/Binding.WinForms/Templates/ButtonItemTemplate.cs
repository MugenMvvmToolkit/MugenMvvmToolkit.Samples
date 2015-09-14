using System;
using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace Binding.WinForms.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, Type>, Button>
    {
        #region Fields

        public static readonly ButtonItemTemplate Instance = new ButtonItemTemplate();

        #endregion

        #region Constructors

        private ButtonItemTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<Tuple<string,Type>,Button>

        protected override Button SelectTemplate(Tuple<string, Type> item, object container)
        {
            return new Button {Height = 24, Dock = DockStyle.Top};
        }

        protected override void Initialize(Button template, BindingSet<Button, Tuple<string, Type>> bindingSet)
        {
            bindingSet.Bind(() => button => button.Text).To(() => tuple => tuple.Item1).OneTime();
            bindingSet.Bind()
                .To(() => t => BindingSyntaxEx.Relative<Form>().DataContext<MainViewModel>().ShowCommand)
                .OneTime()
                .WithCommandParameter(() => tuple => tuple.Item2);
        }

        #endregion
    }
}