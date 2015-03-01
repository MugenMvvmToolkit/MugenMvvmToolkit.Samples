using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Annotations;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces.Collections;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.ViewModels.Orders
{
    public class OrderWorkspaceViewModel : WorkspaceViewModel, IHasState
    {
        #region Fields

        private static readonly DataConstant<TrackingCollection> StateConstant;

        private readonly IMessagePresenter _messagePresenter;
        private readonly IRepository _repository;
        private readonly IToastPresenter _toastPresenter;
        private readonly ITrackingCollection _trackingCollection;

        private string _filterText;
        private Task _initializedTask;
        private GridViewModel<OrderModel> _gridViewModel;

        #endregion

        #region Constructors

        static OrderWorkspaceViewModel()
        {
            StateConstant = DataConstant.Create(() => StateConstant, true);
        }

        public OrderWorkspaceViewModel(IRepository repository, IMessagePresenter messagePresenter,
            IToastPresenter toastPresenter)
        {
            Should.NotBeNull(repository, "repository");
            Should.NotBeNull(messagePresenter, "messagePresenter");
            Should.NotBeNull(toastPresenter, "toastPresenter");

            _repository = repository;
            _messagePresenter = messagePresenter;
            _toastPresenter = toastPresenter;
            _trackingCollection = new TrackingCollection(new CompositeEqualityComparer().AddComparer(OrderModel.KeyComparer).AddComparer(OrderProductModel.KeyComparer));

            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges, this);
            AddOrderCommand = new RelayCommand(AddOrder);
            EditOrderCommand = new RelayCommand<OrderModel>(EditOrder, CanEditOrder, this);
            RemoveOrderCommand = new RelayCommand<OrderModel>(RemoveOrder, CanRemoveOrder, this);
            DisplayName = UiResources.OrderWorkspaceName;
        }

        #endregion

        #region Commands

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand AddOrderCommand { get; private set; }

        public ICommand EditOrderCommand { get; private set; }

        public ICommand RemoveOrderCommand { get; private set; }

        #endregion

        #region Properties

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (value == _filterText) return;
                _filterText = value;
                if (GridViewModel != null)
                    GridViewModel.UpdateFilter();
                OnPropertyChanged();
            }
        }

        public bool HasChanges
        {
            get { return _trackingCollection.HasChanges; }
        }

        public GridViewModel<OrderModel> GridViewModel
        {
            get { return _gridViewModel; }
            private set
            {
                if (_gridViewModel == value)
                    return;
                _gridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command's methods

        private async void SaveChanges(object obj)
        {
            try
            {
                await SaveChanges(true);
            }
            catch (Exception e)
            {
                _messagePresenter.ShowAsync(e.Flatten(false), DisplayName);
            }
        }

        private bool CanSaveChanges(object obj)
        {
            return HasChanges;
        }

        private async void AddOrder(object obj)
        {
            using (var editorVm = GetViewModel<OrderEditorViewModel>())
            using (var editorDialogVm = editorVm.Wrap<IEditorWrapperViewModel>())
            {
                var orderModel = new OrderModel
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now
                };
                editorVm.InitializeEntity(orderModel, true);
                if (!await editorDialogVm.ShowAsync())
                    return;

                //NOTE: wait for load data, in case the view model has been restored.
                await _initializedTask;
                _trackingCollection.UpdateStates(editorVm.ApplyChanges());
                orderModel = editorVm.Entity;
                GridViewModel.OriginalItemsSource.Add(orderModel);
                GridViewModel.SelectedItem = orderModel;
                OnPropertyChanged(() => HasChanges);
            }
        }

        private async void EditOrder(OrderModel obj)
        {
            using (var editorVm = GetViewModel<OrderEditorViewModel>())
            using (var editorDialogVm = editorVm.Wrap<IEditorWrapperViewModel>())
            {
                OrderModel orderModel = obj ?? GridViewModel.SelectedItem;
                IList<OrderProductModel> links = await GetOrLoadProductLinks(orderModel);

                editorVm.InitializeEntity(orderModel, links);
                if (!await editorDialogVm.ShowAsync())
                    return;

                //NOTE: wait for load data, in case the view model has been restored.
                await _initializedTask;
                _trackingCollection.UpdateStates(editorVm.ApplyChanges());
                orderModel = editorVm.Entity;

                //NOTE: update item, in case the view model has been restored.
                if (!GridViewModel.OriginalItemsSource.Contains(orderModel))
                {
                    int index = 0;
                    OrderModel currentItem = GridViewModel
                        .OriginalItemsSource
                        .FirstOrDefault(model => model.Id == orderModel.Id);
                    if (currentItem != null)
                    {
                        index = GridViewModel.OriginalItemsSource.IndexOf(currentItem);
                        GridViewModel.OriginalItemsSource.RemoveAt(index);
                    }
                    GridViewModel.OriginalItemsSource.Insert(index, orderModel);
                }

                GridViewModel.SelectedItem = orderModel;
                OnPropertyChanged(() => HasChanges);
            }
        }

        private bool CanEditOrder(OrderModel obj)
        {
            return obj != null || (GridViewModel != null && GridViewModel.SelectedItem != null);
        }

        private async void RemoveOrder(OrderModel obj)
        {
            OrderModel item = obj ?? GridViewModel.SelectedItem;
            string message = string.Format(UiResources.DeleteOrderQuestionFormat, item.Name);
            if (await _messagePresenter.ShowAsync(message, DisplayName, MessageButton.YesNo, MessageImage.Question) !=
                MessageResult.Yes)
                return;

            var productModels = await GetOrLoadProductLinks(item);
            _trackingCollection.UpdateState(item, EntityState.Deleted);
            _trackingCollection.UpdateStates(productModels, EntityState.Deleted);
            GridViewModel.OriginalItemsSource.Remove(item);
            OnPropertyChanged(() => HasChanges);
        }

        private bool CanRemoveOrder(OrderModel obj)
        {
            return obj != null || (GridViewModel != null && GridViewModel.SelectedItem != null);
        }

        #endregion

        #region Methods

        [SuppressTaskBusyHandler]
        private async Task<IList<OrderProductModel>> GetOrLoadProductLinks(OrderModel order)
        {
            if (!_trackingCollection.Contains(order))
            {
                IList<OrderProductModel> items = await _repository
                    .GetProductsByOrderAsync(order.Id)
                    .WithBusyIndicator(this);
                _trackingCollection.UpdateStates(items, EntityState.Unchanged);
                return items;
            }
            return _trackingCollection.Find<OrderProductModel>(item => !item.State.IsDeleted() && item.Entity.IdOrder == order.Id);
        }

        private bool Filter(OrderModel item)
        {
            if (item == null)
                return false;
            if (string.IsNullOrWhiteSpace(FilterText))
                return true;
            return item.Name.SafeContains(FilterText)
                   || item.Number.SafeContains(FilterText);
        }

        [SuppressTaskBusyHandler]
        private async Task SaveChanges(bool showToast)
        {
            await _repository
                .SaveAsync(_trackingCollection.GetChanges(), DisposeCancellationToken)
                .WithBusyIndicator(this, UiResources.SaveBusyMessage);
            _trackingCollection.SetStateForAll(entity => entity.State.IsDeleted(), EntityState.Detached);
            _trackingCollection.SetStateForAll(entity => !entity.State.IsDeleted(), EntityState.Unchanged);
            OnPropertyChanged(() => HasChanges);
            if (showToast)
                _toastPresenter.ShowAsync(UiResources.SaveToastMessage, ToastDuration.Long);
        }

        #endregion

        #region Overrides of WorkspaceViewModel

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<OrderModel>>();
            GridViewModel.Filter = Filter;
            _initializedTask = _repository
                .GetOrdersAsync(DisposeCancellationToken)
                .TryExecuteSynchronously(task => GridViewModel.UpdateItemsSource(task.Result))
                .WithBusyIndicator(this);
        }

        protected override async Task<bool> OnClosing(object parameter)
        {
            if (!HasChanges)
                return true;
            MessageResult result = await _messagePresenter
                .ShowAsync(UiResources.SaveQuestionMessage, DisplayName, MessageButton.YesNoCancel,
                    MessageImage.Question);
            if (result == MessageResult.Yes)
            {
                await SaveChanges(false);
                return true;
            }
            return result == MessageResult.No;
        }

        #endregion

        #region Implementation of IHasState

        public async void LoadState(IDataContext state)
        {
            TrackingCollection trackingCollection = state.GetData(StateConstant);
            if (trackingCollection == null)
                return;
            IList<IEntityStateEntry> changes = trackingCollection.GetChanges();
            await _initializedTask;
            _trackingCollection.UpdateStates(changes);
            foreach (IEntityStateEntry change in changes)
            {
                var oldOrder = change.Entity as OrderModel;
                if (oldOrder == null)
                    _trackingCollection.UpdateState(change);
                else
                {
                    OrderModel currentOrder = GridViewModel.OriginalItemsSource.FirstOrDefault(model => model.Id == oldOrder.Id);
                    switch (change.State)
                    {
                        case EntityState.Added:
                            GridViewModel.OriginalItemsSource.Add(oldOrder);
                            break;
                        case EntityState.Modified:
                            if (currentOrder != null)
                                GridViewModel.OriginalItemsSource.Remove(currentOrder);
                            GridViewModel.OriginalItemsSource.Add(oldOrder);
                            break;
                        case EntityState.Deleted:
                            if (currentOrder != null)
                                GridViewModel.OriginalItemsSource.Remove(currentOrder);
                            break;
                    }
                }
            }
            OnPropertyChanged(() => HasChanges);
        }

        public void SaveState(IDataContext state)
        {
            IList<IEntityStateEntry> changes = _trackingCollection.GetChanges();
            if (changes.Count != 0)
                state.AddOrUpdate(StateConstant, new TrackingCollection(changes));
        }

        #endregion
    }
}