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

        protected override TabPage SelectTemplate(ItemViewModel item, object container)
        {
            return new TabPage();
        }

        protected override void Initialize(TabPage template, BindingSet<TabPage, ItemViewModel> bindingSet)
        {
            bindingSet.Bind(() => page => page.Text).To(() => (model, ctx) => model.Name);

            var label = new Label();
            bindingSet.Bind(label).To(() => (model, ctx) => model.Id);
            template.Controls.Add(label);
        }

        #endregion
    }
}