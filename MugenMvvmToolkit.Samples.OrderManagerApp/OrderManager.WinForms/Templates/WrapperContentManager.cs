using System.Windows.Forms;
using MugenMvvmToolkit.WinForms.Binding.Infrastructure;
using OrderManager.WinForms.Views;

namespace OrderManager.WinForms.Templates
{
    public class WrapperContentManager : ContentViewManagerBase<EditorWrapperView, Control>
    {
        #region Fields

        public static readonly WrapperContentManager Instance = new WrapperContentManager();

        #endregion

        #region Constructors

        private WrapperContentManager()
        {
        }

        #endregion

        #region Overrides of ContentViewManagerBase<EditorWrapperView,Control>

        protected override void SetContent(EditorWrapperView view, Control content)
        {
            view.SetContent(content);
        }

        #endregion
    }
}