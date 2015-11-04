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

        private readonly IMessagePresenter _messagePresenter;

        private readonly IDynamicViewModelPresenter _presenter;
        private readonly IToastPresenter _toastPresenter;
        private readonly IViewModelPresenter _viewModelPresenter;

        #endregion

        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter, IToastPresenter toastPresenter, IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(viewModelPresenter, "viewModelPresenter");
            Should.NotBeNull(toastPresenter, "toastPresenter");
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _viewModelPresenter = viewModelPresenter;
            _toastPresenter = toastPresenter;
            _messagePresenter = messagePresenter;
            ShowFirstWindowCommand = RelayCommandBase.FromAsyncHandler(ShowFirstWindow);
            ShowSecondWindowCommand = RelayCommandBase.FromAsyncHandler(ShowSecondWindow);
            ShowFirstTabCommand = RelayCommandBase.FromAsyncHandler(ShowFirstTab);
            ShowSecondTabCommand = RelayCommandBase.FromAsyncHandler(ShowSecondTab);
            ShowFirstPageCommand = RelayCommandBase.FromAsyncHandler(ShowFirstPage);
            ShowSecondPageCommand = RelayCommandBase.FromAsyncHandler(ShowSecondPage);
            ShowBackStackPageCommand = RelayCommandBase.FromAsyncHandler(ShowBackStackPage);

            //NOTE The DynamicMultiViewModelPresenter allows to use the current view model as presenter.
            _presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(_presenter);
        }

        #endregion

        #region Methods

        private void ShowOpenNotification(IViewModel viewModel, string type)
        {
            _toastPresenter.ShowAsync(string.Format("The '{0}' is opened ({1}).", viewModel.GetType().Name, type), ToastDuration.Short);
        }

        private void ShowCloseNotification(IViewModel viewModel, string type)
        {
            _toastPresenter.ShowAsync(string.Format("The '{0}' is closed ({1}).", viewModel.GetType().Name, type), ToastDuration.Short);
        }

        #region Overrides of ViewModelBase

        public override async Task<bool> CloseAsync(object parameter = null)
        {
            if (ItemsSource.Count == 0)
                return await _messagePresenter.ShowAsync("Are you sure you want to exit?", "Exit", MessageButton.YesNo) == MessageResult.Yes;
            return await base.CloseAsync(parameter);
        }

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                _viewModelPresenter.DynamicPresenters.Remove(_presenter);
            base.OnDispose(disposing);
        }

        #endregion

        #endregion

        #region Commands

        public ICommand ShowFirstWindowCommand { get; private set; }

        public ICommand ShowSecondWindowCommand { get; private set; }

        public ICommand ShowFirstTabCommand { get; private set; }

        public ICommand ShowSecondTabCommand { get; private set; }

        public ICommand ShowFirstPageCommand { get; private set; }

        public ICommand ShowSecondPageCommand { get; private set; }

        public ICommand ShowBackStackPageCommand { get; private set; }

        private async Task ShowFirstWindow()
        {
            using (var vm = GetViewModel<FirstViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.WindowPreferably.ToValue(true)))
            {
                var operation = wrapper.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Window");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Window");
            }
        }

        private async Task ShowSecondWindow()
        {
            using (var vm = GetViewModel<SecondViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.WindowPreferably.ToValue(true)))
            {
                var operation = wrapper.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Window");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Window");
            }
        }

        private async Task ShowFirstPage()
        {
            using (var vm = GetViewModel<FirstViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.PagePreferably.ToValue(true)))
            {
                var operation = wrapper.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Page");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Page");
            }
        }

        private async Task ShowSecondPage()
        {
            using (var vm = GetViewModel<SecondViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.PagePreferably.ToValue(true)))
            {
                var operation = wrapper.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Page");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Page");
            }
        }

        private async Task ShowFirstTab()
        {
            using (var vm = GetViewModel<FirstViewModel>())
            {
                var operation = vm.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Tab");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Tab");
            }
        }

        private async Task ShowSecondTab()
        {
            using (var vm = GetViewModel<SecondViewModel>())
            {
                var operation = vm.ShowAsync();

                //wait until the view model is displayed.
                await operation.NavigationCompletedTask;
                ShowOpenNotification(vm, "Tab");

                //wait until the view model is closed.
                await operation;
                ShowCloseNotification(vm, "Tab");
            }
        }

        private async Task ShowBackStackPage()
        {
            using (var vm = GetViewModel<BackStackViewModel>())
                await vm.ShowAsync();
        }

        #endregion

        #region Implementation of interfaces

        public void LoadState(IDataContext state)
        {
            RestoreViewModels(state);
        }

        public void SaveState(IDataContext state)
        {
            PreserveViewModels(state);
        }

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            this.TraceNavigation(context);
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            this.TraceNavigation(context);
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
            this.TraceNavigation(context);
        }

        #endregion
    }
}