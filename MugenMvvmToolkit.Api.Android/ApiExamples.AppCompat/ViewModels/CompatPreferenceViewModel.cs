using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class CompatPreferenceViewModel : ViewModelBase
    {
        #region Properties

        public PreferenceViewModel Content { get; private set; }

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            Content = GetViewModel<PreferenceViewModel>();
        }

        #endregion
    }
}