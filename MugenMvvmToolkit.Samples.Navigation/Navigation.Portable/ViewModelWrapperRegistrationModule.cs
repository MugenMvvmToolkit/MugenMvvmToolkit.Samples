using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Modules;
using Navigation.Portable.Interfaces;
using Navigation.Portable.ViewModels;

namespace Navigation.Portable
{
    public class ViewModelWrapperRegistrationModule : WrapperRegistrationModuleBase
    {
        #region Overrides of WrapperRegistrationModuleBase

        /// <summary>
        ///     Registers the wrappers using <see cref="T:MugenMvvmToolkit.Infrastructure.WrapperManager" /> class.
        /// </summary>
        protected override void RegisterWrappers(WrapperManager wrapperManager)
        {
            wrapperManager.AddWrapper<IWrapper, WrapperWindowViewModel>(
                (type, context) => context.Contains(Constants.WindowPreferably));
            wrapperManager.AddWrapper<IWrapper, WrapperPageViewModel>(
                (model, context) => context.Contains(Constants.PagePreferably));
        }

        #endregion
    }
}