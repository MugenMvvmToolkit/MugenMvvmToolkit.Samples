using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Modules;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Portable
{
    public class ViewModelWrapperRegistrationModule : WrapperRegistrationModuleBase
    {
        #region Overrides of WrapperRegistrationModuleBase

        protected override void RegisterWrappers(WrapperManager wrapperManager)
        {
            wrapperManager.AddWrapper<IEditorWrapperViewModel>(typeof (EditorWrapperViewModel<>));
        }

        #endregion
    }
}