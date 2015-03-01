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
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.ViewModels.Products
{
    public class ProductWorkspaceViewModel : WorkspaceViewModel, IHasState
    {
        #region Fields

        private static readonly DataConstant<ITrackingCollection> StateConstant;

        private readonly IMessagePresenter _messagePresenter;
        private readonly IRepository _repository;
        private readonly IToastPresenter _toastPresenter;
        private readonly ITrackingCollection _trackingCollection;

        private string _filterText;
        private GridViewModel<ProductModel> _gridViewModel;
        private Task _initializedTask;

        #endregion

        #region Constructors

        static ProductWorkspaceViewModel()
        {
            StateConstant = DataConstant.Create(() => StateConstant, true);
        }

        public ProductWorkspaceViewModel(IRepository repository, IMessagePresenter messagePresenter,
            IToastPresenter toastPresenter)
        {
            Should.NotBeNull(repository, "repository");
            Should.NotBeNull(messagePresenter, "messagePresenter");
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _repository = repository;
            _messagePresenter = messagePresenter;
            _toastPresenter = toastPresenter;
            _trackingCollection = new TrackingCollection(new CompositeEqualityComparer().AddComparer(ProductModel.KeyComparer));

            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges, this);
            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommand = new RelayCommand<ProductModel>(EditProduct, CanEditProduct, this);
            RemoveProductCommand = new RelayCommand<ProductModel>(RemoveProduct, CanRemoveProduct, this);
            DisplayName = UiResources.ProductWorkspaceName;
        }

        #endregion

        #region Commands

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand AddProductCommand { get; private set; }

        public ICommand EditProductCommand { get; private set; }

        public ICommand RemoveProductCommand { get; private set; }

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

        private async void AddProduct(object obj)
        {
            using (var editorVm = GetViewModel<ProductEditorViewModel>())
            using (var editorWrapperViewModel = editorVm.Wrap<IEditorWrapperViewModel>())
            {
                var productModel = new ProductModel { Id = Guid.NewGuid() };
                editorVm.InitializeEntity(productModel, true);
                if (!await editorWrapperViewModel.ShowAsync())
                    return;

                //NOTE: wait for load data, in case the view model has been restored.
                await _initializedTask;

                _trackingCollection.UpdateStates(editorVm.ApplyChanges());
                productModel = editorVm.Entity;
                GridViewModel.OriginalItemsSource.Add(productModel);
                GridViewModel.SelectedItem = productModel;
                OnPropertyChanged(() => HasChanges);
            }
        }

        private async void EditProduct(ProductModel obj)
        {
            using (var editorVm = GetViewModel<ProductEditorViewModel>())
            using (var editorDialogVm = editorVm.Wrap<IEditorWrapperViewModel>())
            {
                var productModel = obj ?? GridViewModel.SelectedItem;
                editorVm.InitializeEntity(productModel, false);
                if (!await editorDialogVm.ShowAsync())
                    return;

                //NOTE: wait for load data, in case the view model has been restored.
                await _initializedTask;
                _trackingCollection.UpdateStates(editorVm.ApplyChanges());
                productModel = editorVm.Entity;

                //NOTE: update item, in case the view model has been restored.
                if (!GridViewModel.OriginalItemsSource.Contains(productModel))
                {
                    int index = 0;
                    ProductModel currentItem = GridViewModel
                        .OriginalItemsSource
                        .FirstOrDefault(model => model.Id == productModel.Id);
                    if (currentItem != null)
                    {
                        index = GridViewModel.OriginalItemsSource.IndexOf(currentItem);
                        GridViewModel.OriginalItemsSource.RemoveAt(index);
                    }
                    GridViewModel.OriginalItemsSource.Insert(index, productModel);
                }

                GridViewModel.SelectedItem = productModel;
                OnPropertyChanged(() => HasChanges);
            }
        }

        private bool CanEditProduct(ProductModel obj)
        {
            return obj != null || (GridViewModel != null && GridViewModel.SelectedItem != null);
        }

        private async void RemoveProduct(ProductModel obj)
        {
            ProductModel item = obj ?? GridViewModel.SelectedItem;
            string message = string.Format(UiResources.DeleteProductQuestionFormat, item.Name);
            if (await _messagePresenter.ShowAsync(message, DisplayName, MessageButton.YesNo, MessageImage.Question) !=
                MessageResult.Yes)
                return;
            _trackingCollection.UpdateState(item, EntityState.Deleted);
            GridViewModel.OriginalItemsSource.Remove(item);
            OnPropertyChanged(() => HasChanges);
        }

        private bool CanRemoveProduct(object obj)
        {
            return obj != null || (GridViewModel != null && GridViewModel.SelectedItem != null);
        }

        #endregion

        #region Properties

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (value == _filterText)
                    return;
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

        public GridViewModel<ProductModel> GridViewModel
        {
            get { return _gridViewModel; }
            private set
            {
                if (Equals(value, _gridViewModel))
                    return;
                _gridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private bool FilterProduct(ProductModel item)
        {
            if (item == null)
                return false;
            if (string.IsNullOrWhiteSpace(FilterText))
                return true;
            return item.Name.SafeContains(FilterText)
                   || item.Description.SafeContains(FilterText);
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

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<ProductModel>>();
            GridViewModel.Filter = FilterProduct;
            _initializedTask = _repository
                .GetProductsAsync(DisposeCancellationToken)
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
            ITrackingCollection trackingCollection = state.GetData(StateConstant);
            if (trackingCollection == null)
                return;
            IList<IEntityStateEntry> changes = trackingCollection.GetChanges();
            await _initializedTask;
            _trackingCollection.UpdateStates(changes);
            foreach (IEntityStateEntry change in changes)
            {
                var oldItem = (ProductModel)change.Entity;
                ProductModel currentItem = GridViewModel.OriginalItemsSource.FirstOrDefault(model => model.Id == oldItem.Id);
                switch (change.State)
                {
                    case EntityState.Added:
                        GridViewModel.OriginalItemsSource.Add(oldItem);
                        break;
                    case EntityState.Modified:
                        if (currentItem != null)
                            GridViewModel.OriginalItemsSource.Remove(currentItem);
                        GridViewModel.OriginalItemsSource.Add(oldItem);
                        break;
                    case EntityState.Deleted:
                        if (currentItem != null)
                            GridViewModel.OriginalItemsSource.Remove(currentItem);
                        break;
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