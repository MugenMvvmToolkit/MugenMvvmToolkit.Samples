using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Portable.Infrastructure
{
    public class ViewModelWrapperManager : ViewModelWrapperManagerBase
    {
        #region Constructors

        public ViewModelWrapperManager(IViewModelProvider viewModelProvider)
            : base(viewModelProvider)
        {
            AddWrapper<IEditorWrapperViewModel>(typeof (EditorWrapperViewModel<>));
        }

        #endregion
    }
}