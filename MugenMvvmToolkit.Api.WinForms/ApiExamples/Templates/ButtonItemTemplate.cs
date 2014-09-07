using System;
using System.Windows.Forms;
using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.Templates
{
    public class ButtonItemTemplate : DataTemplateSelectorBase<Tuple<string, ViewModelCommandParameter>, Button>
    {
        #region Overrides of DataTemplateSelectorBase<Tuple<string,Type>,Button>

        /// <summary>
        ///     Override this method to return an app specific template id.
        /// </summary>
        /// <param name="item">The data content</param>
        /// <param name="container">The element to which the template will be applied</param>
        /// <returns>
        ///     An app-specific template to apply, or null.
        /// </returns>
        protected override Button SelectTemplate(Tuple<string, ViewModelCommandParameter> item, object container)
        {
            return new Button {Height = 24, Dock = DockStyle.Top};
        }

        /// <summary>
        ///     Initializes the specified template.
        /// </summary>
        protected override void Initialize(Button template, BindingSet<Button, Tuple<string, ViewModelCommandParameter>> bindingSet)
        {
            bindingSet.Bind(button => button.Text).To(tuple => tuple.Item1);
            bindingSet.Bind(AttachedMemberConstants.CommandParameter).To(tuple => tuple.Item2);
            bindingSet.BindFromExpression("Click $Relative(Form).DataContext.ShowCommand");
        }

        #endregion
    }
}