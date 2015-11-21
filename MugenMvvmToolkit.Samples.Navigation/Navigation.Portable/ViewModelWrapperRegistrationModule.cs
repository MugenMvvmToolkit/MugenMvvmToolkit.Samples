using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Modules;
using Navigation.Portable.Interfaces;
using Navigation.Portable.ViewModels;

namespace Navigation.Portable
{
    public class ViewModelWrapperRegistrationModule : WrapperRegistrationModuleBase
    {
        #region Overrides of WrapperRegistrationModuleBase

        protected override void RegisterWrappers(IConfigurableWrapperManager wrapperManager)
        {
            wrapperManager.AddWrapper<IWrapper, WrapperWindowViewModel>(
                (type, context) => context.Contains(Constants.WindowPreferably));
            wrapperManager.AddWrapper<IWrapper, WrapperPageViewModel>(
                (model, context) => context.Contains(Constants.PagePreferably));
        }

        #endregion        
    }
}