using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Navigation.Portable.Interfaces;

namespace Navigation.Portable.ViewModels
{
    public class MainViewModel : MultiViewModel, IHasState, INavigableViewModel
    {
        #region Fields

        private readonly IDynamicViewModelPresenter _presenter;
        private readonly IToastPresenter _toastPresenter;
        private readonly IViewModelPresenter _viewModelPresenter;

        #endregion

        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter, IToastPresenter toastPresenter)
        {
            Should.NotBeNull(viewModelPresenter, "viewModelPresenter");
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _viewModelPresenter = viewModelPresenter;
            _toastPresenter = toastPresenter;
            ShowFirstWindowCommand = new RelayCommand(ShowFirstWindow);
            ShowSecondWindowCommand = new RelayCommand(ShowSecondWindow);
            ShowFirstTabCommand = new RelayCommand(ShowFirstTab);
            ShowSecondTabCommand = new RelayCommand(ShowSecondTab);
            ShowFirstPageCommand = new RelayCommand(ShowFirstPage);
            ShowSecondPageCommand = new RelayCommand(ShowSecondPage);
            ShowBackStackPageCommand = new RelayCommand(ShowBackStackPage);

            //NOTE The DynamicMultiViewModelPresenter allows to use the current view model as presenter.
            _presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(_presenter);
        }

        #endregion

        #region Commands

        public ICommand ShowFirstWindowCommand { get; private set; }

        public ICommand ShowSecondWindowCommand { get; private set; }

        public ICommand ShowFirstTabCommand { get; private set; }

        public ICommand ShowSecondTabCommand { get; private set; }

        public ICommand ShowFirstPageCommand { get; private set; }

        public ICommand ShowSecondPageCommand { get; private set; }

        public ICommand ShowBackStackPageCommand { get; private set; }

        private async void ShowFirstWindow(object o)
        {
            using (var vm = GetViewModel<FirstViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.WindowPreferably.ToValue(true)))
            {
                await wrapper.ShowAsync();
                _toastPresenter.ShowAsync("The first view model is closed (Window).", ToastDuration.Short);
            }
        }

        private async void ShowSecondWindow(object o)
        {
            using (var vm = GetViewModel<SecondViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.WindowPreferably.ToValue(true)))
            {
                await wrapper.ShowAsync();
                _toastPresenter.ShowAsync("The second view model is closed (Window).", ToastDuration.Short);
            }
        }

        private async void ShowFirstPage(object o)
        {
            using (var vm = GetViewModel<FirstViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.PagePreferably.ToValue(true)))
            {
                await wrapper.ShowAsync();
                _toastPresenter.ShowAsync("The first view model is closed (Page).", ToastDuration.Short);
            }
        }

        private async void ShowSecondPage(object o)
        {
            using (var vm = GetViewModel<SecondViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.PagePreferably.ToValue(true)))
            {
                await wrapper.ShowAsync();
                _toastPresenter.ShowAsync("The second view model is closed (Page).", ToastDuration.Short);
            }
        }

        private async void ShowFirstTab(object o)
        {
            using (var vm = GetViewModel<FirstViewModel>())
            {
                await vm.ShowAsync();
                _toastPresenter.ShowAsync("The first view model is closed (Tab).", ToastDuration.Short);
            }
        }

        private async void ShowSecondTab(object o)
        {
            using (var vm = GetViewModel<SecondViewModel>())
            {
                await vm.ShowAsync();
                _toastPresenter.ShowAsync("The second view model is closed (Tab).", ToastDuration.Short);
            }
        }

        private async void ShowBackStackPage(object obj)
        {
            using (var vm = GetViewModel<BackStackViewModel>())
                await vm.ShowAsync();
        }

        #endregion

        #region Implementation of IHasState

        public void LoadState(IDataContext state)
        {
            RestoreViewModels(state);
        }

        public void SaveState(IDataContext state)
        {
            PreserveViewModels(state);
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                _viewModelPresenter.DynamicPresenters.Remove(_presenter);
            base.OnDispose(disposing);
        }

        #endregion

        #region Implementation of INavigableViewModel

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            this.TraceNavigation();
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            this.TraceNavigation();
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
            this.TraceNavigation();
        }

        #endregion
    }
}