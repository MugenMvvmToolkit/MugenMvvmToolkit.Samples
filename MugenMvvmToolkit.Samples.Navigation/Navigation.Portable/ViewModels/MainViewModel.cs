using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Navigation.Portable.Interfaces;

namespace Navigation.Portable.ViewModels
{
    public class MainViewModel : MultiViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter, IToastPresenter toastPresenter)
        {
            Should.NotBeNull(viewModelPresenter, "viewModelPresenter");
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _toastPresenter = toastPresenter;
            ShowFirstWindowCommand = new RelayCommand(ShowFirstWindow);
            ShowSecondWindowCommand = new RelayCommand(ShowSecondWindow);
            ShowFirstTabCommand = new RelayCommand(ShowFirstTab);
            ShowSecondTabCommand = new RelayCommand(ShowSecondTab);
            ShowFirstPageCommand = new RelayCommand(ShowFirstPage);
            ShowSecondPageCommand = new RelayCommand(ShowSecondPage);

            //NOTE The DynamicMultiViewModelPresenter allows to use the current view model as presenter.
            viewModelPresenter.DynamicPresenters.Add(new DynamicMultiViewModelPresenter(this));
        }

        #endregion

        #region Commands

        public ICommand ShowFirstWindowCommand { get; private set; }

        public ICommand ShowSecondWindowCommand { get; private set; }

        public ICommand ShowFirstTabCommand { get; private set; }

        public ICommand ShowSecondTabCommand { get; private set; }

        public ICommand ShowFirstPageCommand { get; private set; }

        public ICommand ShowSecondPageCommand { get; private set; }

        private async void ShowFirstWindow(object o)
        {
            using (var vm = GetViewModel<FirstViewModel>())
            using (var wrapper = vm.Wrap<IWrapper>(Constants.WindowPreferably.ToValue(true)))
            {
                await wrapper.ShowAsync();
                await _toastPresenter.ShowAsync("The first view model is closed (Window).", ToastDuration.Long);
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

        #endregion
    }
}