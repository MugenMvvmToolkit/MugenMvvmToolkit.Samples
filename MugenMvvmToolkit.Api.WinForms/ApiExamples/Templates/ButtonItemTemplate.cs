using System;
using System.Windows.Forms;
using ApiExamples.Models;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, ViewModelCommandParameter>, Button>
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

        protected override Button SelectTemplate(Tuple<string, ViewModelCommandParameter> item, object container)
        {
            return new Button { Height = 24, Dock = DockStyle.Top };
        }

        protected override void Initialize(Button template,
            BindingSet<Button, Tuple<string, ViewModelCommandParameter>> bindingSet)
        {
            bindingSet.Bind(() => button => button.Text).To(() => (tuple, ctx) => tuple.Item1);
            bindingSet.Bind()
                      .To(() => (tuple, ctx) => ctx.Relative<Form>().DataContext<MainViewModel>().ShowCommand)
                      .WithCommandParameter(() => (tuple, ctx) => tuple.Item2);
        }

        #endregion
    }
}