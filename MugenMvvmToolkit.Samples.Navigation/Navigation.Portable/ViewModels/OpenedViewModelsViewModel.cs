using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class OpenedViewModelsViewModel : WorkspaceViewModel
    {
        #region Nested types

        public class OpenedViewModelInfo
        {
            #region Constructors

            public OpenedViewModelInfo(NavigationType navigationType, string name, IViewModel viewModel)
            {
                NavigationType = navigationType;
                Name = name;
                ViewModel = viewModel;
            }

            #endregion

            #region Properties

            public NavigationType NavigationType { get; }

            public string Name { get; }

            public IViewModel ViewModel { get; }

            #endregion
        }

        public class MenuItem
        {
            #region Constructors

            public MenuItem(string name, ICommand command, OpenedViewModelInfo commandParameter)
            {
                Name = name;
                Command = command;
                CommandParameter = commandParameter;
            }

            #endregion

            #region Properties

            public string Name { get; }

            public ICommand Command { get; }

            public OpenedViewModelInfo CommandParameter { get; }

            #endregion
        }

        #endregion

        #region Fields

        private readonly INavigationDispatcher _navigationDispatcher;
        private readonly IToastPresenter _toastPresenter;
        private IList<OpenedViewModelInfo> _openedViewModels;

        #endregion

        #region Constructors

        public OpenedViewModelsViewModel(INavigationDispatcher navigationDispatcher, IToastPresenter toastPresenter)
        {
            _navigationDispatcher = navigationDispatcher;
            _toastPresenter = toastPresenter;
            TryCloseCommand = new AsyncRelayCommand<OpenedViewModelInfo>(TryCloseAsync);
            TryImmediateCloseCommand = new AsyncRelayCommand<OpenedViewModelInfo>(TryImmediateCloseAsync);
            TryOpenCommand = new AsyncRelayCommand<OpenedViewModelInfo>(TryOpenAsync);
            TryOpenClearBackStackCommand = new AsyncRelayCommand<OpenedViewModelInfo>(TryOpenClearBackStackAsync);
        }

        private async Task TryCloseAsync(OpenedViewModelInfo openedViewModelInfo)
        {
            if (!await openedViewModelInfo.ViewModel.CloseAsync())
                _toastPresenter.ShowAsync($"Cannot close {openedViewModelInfo.ViewModel.GetType().Name}", ToastDuration.Short);
            RefreshOpenedViewModels();
        }

        private async Task TryImmediateCloseAsync(OpenedViewModelInfo openedViewModelInfo)
        {
            if (!await openedViewModelInfo.ViewModel.CloseAsync(new DataContext { { NavigationConstants.ImmediateClose, true } }))
                _toastPresenter.ShowAsync($"Cannot close {openedViewModelInfo.ViewModel.GetType().Name}", ToastDuration.Short);
            RefreshOpenedViewModels();
        }

        private async Task TryOpenAsync(OpenedViewModelInfo openedViewModelInfo)
        {
            var navigationCompletedTask = openedViewModelInfo.ViewModel.ShowAsync().GetNavigationCompletedTask();
            if (!await navigationCompletedTask)
                _toastPresenter.ShowAsync($"Cannot reopen {openedViewModelInfo.ViewModel.GetType().Name}", ToastDuration.Short);
            RefreshOpenedViewModels();
        }

        private async Task TryOpenClearBackStackAsync(OpenedViewModelInfo openedViewModelInfo)
        {
            var navigationCompletedTask = openedViewModelInfo.ViewModel.ShowAsync(NavigationConstants.ClearBackStack.ToValue(true)).GetNavigationCompletedTask();
            if (!await navigationCompletedTask)
                _toastPresenter.ShowAsync($"Cannot reopen clear back stack {openedViewModelInfo.ViewModel.GetType().Name}", ToastDuration.Short);
            RefreshOpenedViewModels();
        }

        #endregion

        #region Properties

        public IList<OpenedViewModelInfo> OpenedViewModels
        {
            get { return _openedViewModels; }
            private set
            {
                if (Equals(value, _openedViewModels)) return;
                _openedViewModels = value;
                OnPropertyChanged();
            }
        }

        public ICommand TryCloseCommand { get; }

        public ICommand TryImmediateCloseCommand { get; }

        public ICommand TryOpenCommand { get; }

        public ICommand TryOpenClearBackStackCommand { get; }

        #endregion

        #region Methods

        public IList<MenuItem> GetMenuItems(OpenedViewModelInfo info)
        {
            if (info.ViewModel == null)
                return null;
            var items = new List<MenuItem>();
            Func<IViewModel, object, bool> canClose;
            if (!info.ViewModel.Settings.Metadata.TryGetData(ViewModelConstants.CanCloseHandler, out canClose) || canClose(info.ViewModel, null))
            {
                items.Add(new MenuItem("Try Close", TryCloseCommand, info));
                items.Add(new MenuItem("Try Immediate Close", TryImmediateCloseCommand, info));
            }
            if (info.ViewModel != this)
            {
                items.Add(new MenuItem("Try Reopen", TryOpenCommand, info));
                if (info.NavigationType == NavigationType.Page)
                    items.Add(new MenuItem("Try Reopen Clear Back Stack", TryOpenClearBackStackCommand, info));
            }
            return items;
        }

        protected override void OnNavigatedTo(INavigationContext context)
        {
            base.OnNavigatedTo(context);
            RefreshOpenedViewModels();
        }

        private void RefreshOpenedViewModels()
        {
            var openedViewModels = _navigationDispatcher.GetOpenedViewModels();
            var result = new List<OpenedViewModelInfo>();
            foreach (var openedViewModel in openedViewModels)
            {
                result.Add(new OpenedViewModelInfo(openedViewModel.Key, "Navigation type " + openedViewModel.Key.Id, null));
                for (var index = 0; index < openedViewModel.Value.Count; index++)
                {
                    var viewModel = openedViewModel.Value[index].ViewModel;
                    var hasDisplayName = viewModel as IHasDisplayName;
                    var name = string.IsNullOrEmpty(hasDisplayName?.DisplayName)
                        ? $"{index + 1}.) {viewModel.GetType().Name}"
                        : $"{index + 1}.) {viewModel.GetType().Name} ({hasDisplayName.DisplayName})";
                    result.Add(new OpenedViewModelInfo(openedViewModel.Key, name, viewModel));
                }
            }
            OpenedViewModels = result;
        }

        #endregion
    }
}