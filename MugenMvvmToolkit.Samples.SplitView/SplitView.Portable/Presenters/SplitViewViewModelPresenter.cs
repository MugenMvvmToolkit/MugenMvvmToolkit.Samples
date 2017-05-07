using System.Linq;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Infrastructure.Callbacks;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Callbacks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.EventArg;
using MugenMvvmToolkit.ViewModels;
using SplitView.Portable.ViewModels;

namespace SplitView.Portable.Presenters
{
    public class SplitViewViewModelPresenter : IDynamicViewModelPresenter
    {
        #region Fields

        private static readonly DataConstant<IDataContext> SelectedItemState = DataConstant.Create(() => SelectedItemState, true);

        private readonly IOperationCallbackManager _callbackManager;
        private readonly INavigationDispatcher _navigationDispatcher;
        private readonly IViewModelProvider _viewModelProvider;
        private static readonly NavigationType SplitViewNavigationType = new NavigationType(nameof(SplitViewNavigationType), new OperationType(nameof(SplitViewNavigationType)));

        #endregion

        #region Constructors

        public SplitViewViewModelPresenter(IViewModelProvider viewModelProvider, INavigationDispatcher navigationDispatcher, IOperationCallbackManager callbackManager)
        {
            _viewModelProvider = viewModelProvider;
            _navigationDispatcher = navigationDispatcher;
            _callbackManager = callbackManager;
            viewModelProvider.Preserved += OnViewModelPreserved;
            viewModelProvider.Restored += OnViewModelRestored;
        }

        #endregion

        #region Properties

        public int Priority => int.MinValue;

        #endregion

        #region Methods

        private static void OnViewModelPreserved(IViewModelProvider sender, ViewModelPreservedEventArgs args)
        {
            var mainViewModel = args.ViewModel as MainViewModel;
            if (mainViewModel?.SelectedItem != null)
                args.State.AddOrUpdate(SelectedItemState, sender.PreserveViewModel(mainViewModel.SelectedItem, DataContext.Empty));
        }

        private static void OnViewModelRestored(IViewModelProvider sender, ViewModelRestoredEventArgs args)
        {
            var mainViewModel = args.ViewModel as MainViewModel;
            if (mainViewModel != null)
            {
                var context = args.State.GetData(SelectedItemState);
                if (context != null)
                    mainViewModel.SelectedItem = sender.RestoreViewModel(context, DataContext.Empty, false);
            }
        }

        private void OnCurrentNavigationsCompleted(IViewModel viewModel)
        {
            var mainViewModel = _navigationDispatcher.GetTopViewModels().OfType<MainViewModel>().FirstOrDefault();
            if (mainViewModel == null)
            {
                mainViewModel = _viewModelProvider.GetViewModel<MainViewModel>();
                mainViewModel.ShowAsync((model, result) => model.Dispose(), context: new DataContext { { NavigationConstants.ClearBackStack, true } });
            }

            var oldValue = mainViewModel.SelectedItem;
            if (oldValue == viewModel)
                return;
            mainViewModel.SelectedItem = viewModel;
            _navigationDispatcher.OnNavigated(new NavigationContext(SplitViewNavigationType, NavigationMode.New, oldValue, viewModel, this));
            if (oldValue != null)
                _navigationDispatcher.OnNavigated(new NavigationContext(SplitViewNavigationType, NavigationMode.Remove, oldValue, null, this));
        }

        #endregion

        #region Implementation of interfaces

        public IAsyncOperation TryShowAsync(IDataContext context, IViewModelPresenter parentPresenter)
        {
            var viewModel = context.GetData(NavigationConstants.ViewModel);
            if (viewModel == null)
                return null;

            var navigationOperation = new AsyncOperation<object>();
            _callbackManager.Register(SplitViewNavigationType.Operation, viewModel, navigationOperation.ToOperationCallback(), context);

            //waiting when all navigations will be completed (Page, Window) to be sure that the MainViewModel is the top view model.
            parentPresenter.WaitCurrentNavigationsAsync(context)
                .ContinueWith(task => OnCurrentNavigationsCompleted(viewModel), TaskScheduler.FromCurrentSynchronizationContext());
            return navigationOperation;
        }

        public Task<bool> TryCloseAsync(IDataContext context, IViewModelPresenter parentPresenter)
        {
            return null;
        }

        #endregion
    }
}