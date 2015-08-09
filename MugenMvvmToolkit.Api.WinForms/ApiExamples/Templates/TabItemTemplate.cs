using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.Templates
{
    public class TabItemTemplate : DataTemplateSelectorBase<ItemViewModel, TabPage>
    {
        #region Fields

        public static readonly TabItemTemplate Instance = new TabItemTemplate();

        #endregion

        #region Constructors

        private TabItemTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<ItemViewModel,Label>

        /// <summary>
        ///     Override this method to return an app specific template id.
        /// </summary>
        /// <param name="item">The data content</param>
        /// <param name="container">The element to which the template will be applied</param>
        /// <returns>
        ///     An app-specific template to apply, or null.
        /// </returns>
        protected override TabPage SelectTemplate(ItemViewModel item, object container)
        {
            return new TabPage();
        }

        /// <summary>
        ///     Initializes the specified template.
        /// </summary>
        protected override void Initialize(TabPage template, BindingSet<TabPage, ItemViewModel> bindingSet)
        {
            bindingSet.Bind(() => page => page.Text).To(() => model => model.Name);

            var label = new Label();
            bindingSet.Bind(label, () => l => l.Text).To(() => model => model.Id);
            template.Controls.Add(label);
        }

        #endregion
    }
}