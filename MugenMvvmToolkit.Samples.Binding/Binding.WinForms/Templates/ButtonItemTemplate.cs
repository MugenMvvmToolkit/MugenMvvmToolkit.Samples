using System;
using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace Binding.WinForms.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, Type>, Button>
    {
        #region Overrides of DataTemplateSelectorBase<Tuple<string,Type>,Button>

        protected override Button SelectTemplate(Tuple<string, Type> item, object container)
        {
            return new Button {Height = 24, Dock = DockStyle.Top};
        }

        protected override void Initialize(Button template, BindingSet<Button, Tuple<string, Type>> bindingSet)
        {
            bindingSet.Bind(button => button.Text).To(tuple => tuple.Item1);
            bindingSet.Bind("CommandParameter").To(tuple => tuple.Item2);
            bindingSet.BindFromExpression("Click $Relative(Form).DataContext.ShowCommand");
        }

        #endregion
    }
}