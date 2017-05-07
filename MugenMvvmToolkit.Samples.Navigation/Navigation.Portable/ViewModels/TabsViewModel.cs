using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class TabsViewModel : MultiViewModel<TabViewModel>, IHasState
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public TabsViewModel(IViewModelPresenter viewModelPresenter, IToastPresenter toastPresenter)
        {
            _toastPresenter = toastPresenter;
            AddTabCommand = new RelayCommand(AddTab);
            AddTabPresenterCommand = new AsyncRelayCommand(AddTabPresenterAsync);
            viewModelPresenter.DynamicPresenters.Add(new DynamicMultiViewModelPresenter(this));
            CloseViewModelsOnClose = true;
        }

        #endregion

        #region Properties

        public ICommand AddTabCommand { get; }

        public ICommand AddTabPresenterCommand { get; }

        #endregion

        #region Methods

        private async Task AddTabPresenterAsync()
        {
            //you can use presenter to show view models
            using (var vm = GetViewModel<TabViewModel>())
            {
                await vm.ShowAsync();
                _toastPresenter.ShowAsync($"The '{vm.DisplayName}' is closed.", ToastDuration.Short);
            }
        }

        private void AddTab()
        {
            //you can add view models directly to MultiViewModel
            var tabViewModel = GetViewModel<TabViewModel>();
            AddViewModel(tabViewModel);
        }

        #endregion

        #region Implementation of interfaces

        void IHasState.LoadState(IDataContext state)
        {
            //you can restore\save opened view models during app preserving\restoration
            RestoreViewModels(state);
        }

        void IHasState.SaveState(IDataContext state)
        {
            PreserveViewModels(state);
        }

        #endregion
    }
}