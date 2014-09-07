using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        #region Properties

        public ItemViewModel ViewModel { get; private set; }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            ViewModel = GetViewModel<ItemViewModel>();
            ViewModel.Name = "Content item";
        }

        #endregion
    }
}