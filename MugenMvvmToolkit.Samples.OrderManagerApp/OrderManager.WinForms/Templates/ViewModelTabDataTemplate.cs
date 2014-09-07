using System.Windows.Forms;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace OrderManager.WinForms.Templates
{
    public class ViewModelTabDataTemplate : IDataTemplateSelector
    {
        #region Implementation of IDataTemplateSelector

        public object SelectTemplate(object item, object container)
        {
            var page = new TabPage();
            var set = new BindingSet<TabPage, IViewModel>(page);
            set.BindFromExpression("Content ;");
            set.BindFromExpression("Text DisplayName");
            set.BindFromExpression("IsBusy IsBusy");
            set.BindFromExpression("BusyMessage BusyMessage");
            set.Apply();

            return page;
        }

        #endregion
    }
}