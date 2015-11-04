using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Callbacks;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Callbacks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;

namespace SplitView.Portable.ViewModels
{
    public class SelectedItemMainViewModel : MainViewModel, IDynamicViewModelPresenter, IHasState
    {
        #region Fields

        private const string StateKey = "SelectedItem";

        private static readonly DataConstant<IOperationCallback> OperationCallbackConstant;
        private static readonly OperationType NavigationType;

        private readonly IViewModelPresenter _presenter;
        private IViewModel _selectedItem;

        #endregion

        #region Constructors

        static SelectedItemMainViewModel()
        {
            NavigationType = new OperationType(typeof(SelectedItemMainViewModel).Name);
            OperationCallbackConstant = DataConstant.Create(() => OperationCallbackConstant, true);
        }

        public SelectedItemMainViewModel(IViewModelPresenter presenter, IToastPresenter toastPresenter) : base(toastPresenter)
        {
            Should.NotBeNull(presenter, "presenter");
            _presenter = presenter;
            _presenter.DynamicPresenters.Add(this);
        }

        #endregion

        #region Properties

        public virtual int Priority
        {
            get { return ViewModelPresenter.DefaultNavigationPresenterPriority + 1; }
        }

        public IViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        protected virtual void OnShowViewModel(IViewModel viewModel)
        {
            InvokeCloseCallback(SelectedItem);
            SelectedItem = viewModel;
        }

        protected static void InvokeCloseCallback(IViewModel viewModel)
        {
            if (viewModel == null)
                return;
            IOperationCallback data;
            if (viewModel.Settings.State.TryGetData(OperationCallbackConstant, out data))
            {
                bool? result = null;
                var hasOperationResult = viewModel as IHasOperationResult;
                if (hasOperationResult != null)
                    result = hasOperationResult.OperationResult;
                data.Invoke(OperationResult.CreateResult(NavigationType, viewModel, result));
            }
        }

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                _presenter.DynamicPresenters.Remove(this);
            base.OnDispose(disposing);
        }

        #endregion

        #region Implementation of interfaces

        public INavigationOperation TryShowAsync(IViewModel viewModel, IDataContext context, IViewModelPresenter parentPresenter)
        {
            if (viewModel == this)
                return null;

            var operation = new NavigationOperation();
            var callback = operation.ToOperationCallback();
            //Saving callback to view model state that will allow us to execute it even after app save\restore cycle.
            viewModel.Settings.State.AddOrUpdate(OperationCallbackConstant, callback);
            OnShowViewModel(viewModel);
            return operation;
        }

        public virtual void LoadState(IDataContext state)
        {
            var context = state.GetData<IDataContext>(StateKey);
            if (context != null)
                SelectedItem = ViewModelProvider.RestoreViewModel(context, null, true);
        }

        public virtual void SaveState(IDataContext state)
        {
            var selectedItem = SelectedItem;
            if (selectedItem != null)
                state.AddOrUpdate(StateKey, ViewModelProvider.PreserveViewModel(selectedItem, null));
        }

        #endregion
    }
}