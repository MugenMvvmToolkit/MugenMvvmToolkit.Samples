using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Modules;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Portable
{
    public class ViewModelWrapperRegistrationModule : WrapperRegistrationModuleBase
    {
        #region Overrides of WrapperRegistrationModuleBase

        protected override void RegisterWrappers(IConfigurableWrapperManager wrapperManager)
        {
            wrapperManager.AddWrapper<IEditorWrapperViewModel>(typeof(EditorWrapperViewModel<>));
        }

        #endregion
    }
}