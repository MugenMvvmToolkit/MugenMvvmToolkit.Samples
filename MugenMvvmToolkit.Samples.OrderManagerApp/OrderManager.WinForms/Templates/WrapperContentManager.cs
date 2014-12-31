using System.Windows.Forms;
using MugenMvvmToolkit.Binding.Infrastructure;
using OrderManager.WinForms.Views;

namespace OrderManager.WinForms.Templates
{
    public class WrapperContentManager : ContentViewManagerBase<EditorWrapperView, Control>
    {
        #region Overrides of ContentViewManagerBase<EditorWrapperView,Control>

        protected override void SetContent(EditorWrapperView view, Control content)
        {
            view.SetContent(content);
        }

        #endregion
    }
}