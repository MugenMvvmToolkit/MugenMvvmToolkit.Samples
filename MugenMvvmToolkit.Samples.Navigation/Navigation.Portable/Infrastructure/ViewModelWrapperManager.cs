using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using Navigation.Portable.Interfaces;
using Navigation.Portable.ViewModels;

namespace Navigation.Portable.Infrastructure
{
    public class ViewModelWrapperManager : ViewModelWrapperManagerBase
    {
        #region Constructors

        public ViewModelWrapperManager(IViewModelProvider viewModelProvider)
            : base(viewModelProvider)
        {
            AddWrapper<IWrapper, WrapperWindowViewModel>((model, context) => context.Contains(Constants.WindowPreferably));
            AddWrapper<IWrapper, WrapperPageViewModel>((model, context) => context.Contains(Constants.PagePreferably));
        }

        #endregion
    }
}