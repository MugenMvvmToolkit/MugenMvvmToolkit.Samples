using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class MainViewModel : WorkspaceViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public MainViewModel(IToastPresenter toastPresenter, IMessagePresenter messagePresenter)
        {
            _toastPresenter = toastPresenter;
            _messagePresenter = messagePresenter;
            ShowDialogCommand = new AsyncRelayCommand(ShowDialogAsync);
            ShowPageCommand = new AsyncRelayCommand(ShowPageAsync);
            ShowBackgroundCommand = new AsyncRelayCommand(ShowBackgroundAsync);
            ShowTabsCommand = new AsyncRelayCommand(ShowTabsAsync);
            ShowResultCommand = new AsyncRelayCommand(ShowResultAsync);
        }

        #endregion

        #region Properties

        public ICommand ShowDialogCommand { get; }

        public ICommand ShowPageCommand { get; }

        public ICommand ShowTabsCommand { get; }

        public ICommand ShowResultCommand { get; }

        public ICommand ShowBackgroundCommand { get; }

        public string Test { get; set; }

        #endregion

        #region Methods

        private Task ShowPageAsync()
        {
            return ShowViewModelWithNotificationAsync<PageViewModel>();
        }

        private Task ShowDialogAsync()
        {
            return ShowViewModelWithNotificationAsync<DialogViewModel>();
        }

        private Task ShowBackgroundAsync()
        {
            return ShowViewModelWithNotificationAsync<BackgroundViewModel>();
        }

        private Task ShowTabsAsync()
        {
            return ShowViewModelWithNotificationAsync<TabsViewModel>();
        }

        private async Task ShowResultAsync()
        {
            using (var vm = GetViewModel<ResultViewModel>())
            {
                var result = await vm.ShowAsync();
                //vm.AnyProperty you can also access any other properties or method in vm
                _messagePresenter.ShowAsync(result, "Result from view model");
            }
        }

        private async Task ShowViewModelWithNotificationAsync<TViewModel>()
            where TViewModel : IViewModel
        {
            using (var viewModel = GetViewModel<TViewModel>())
            {
                var operation = viewModel.ShowAsync();

                //waiting until the view model is displayed, only for example
                operation.GetNavigationCompletedTask().ContinueWith(task =>
                {
                    if (!viewModel.IsDisposed)
                        _toastPresenter.ShowAsync($"The '{viewModel.GetType().Name}' is displayed.", ToastDuration.Short);
                });


                //waiting until the view model is closed
                await operation;
                _toastPresenter.ShowAsync($"The '{viewModel.GetType().Name}' is closed.", ToastDuration.Short);
            }
        }

        #endregion
    }
}