using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.ViewModels.Orders
{
    public class OrderEditorViewModel : EditableViewModel<OrderModel>, IHasDisplayName, IHasState
    {
        #region Nested type

        [DataContract]
        public class ViewModelState
        {
            [DataMember]
            public OrderModel Order { get; set; }

            [DataMember]
            public bool IsNewRecord { get; set; }

            [DataMember]
            public OrderProductModel[] Links { get; set; }

            [DataMember]
            public List<Guid> SelectedProducts { get; set; }
        }

        #endregion

        #region Fields

        private static readonly DataConstant<ViewModelState> StateConstant;

        private readonly IRepository _repository;
        private readonly PropertyChangedEventHandler _propertyChangedEventHandler;

        private Task _initializedTask;
        private string _displayName;
        private string _filterText;
        private OrderProductModel[] _oldLinks;

        #endregion

        #region Constructors

        static OrderEditorViewModel()
        {
            StateConstant = DataConstant.Create(() => StateConstant, true);
        }

        public OrderEditorViewModel(IRepository repository)
        {
            Should.NotBeNull(repository, "repository");
            _repository = repository;
            _propertyChangedEventHandler = ReflectionExtensions.MakeWeakPropertyChangedHandler(this, OnProductModelPropertyChanged);
        }

        #endregion

        #region Properties

        public IList<OrderProductModel> OldLinks
        {
            get { return _oldLinks; }
        }

        public GridViewModel<SelectableWrapper<ProductModel>> GridViewModel { get; private set; }

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                if (Equals(value, Entity.Name))
                    return;
                Entity.Name = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get { return Entity.Number; }
            set
            {
                if (Equals(value, Entity.Number))
                    return;
                Entity.Number = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreationDate
        {
            get { return Entity.CreationDate; }
            set
            {
                if (Equals(value, Entity.CreationDate))
                    return;
                Entity.CreationDate = value;
                OnPropertyChanged();
            }
        }

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

        #endregion

        #region Methods

        public void InitializeEntity(OrderModel entity, IEnumerable<OrderProductModel> links)
        {
            Should.NotBeNull(links, "links");
            _oldLinks = links.ToArray();
            InitializeEntity(entity, false);
        }

        private void RestoreSelection(ICollection<Guid> links)
        {
            foreach (var wrapper in GridViewModel.OriginalItemsSource)
                wrapper.IsSelected = links.Contains(wrapper.Model.Id);
        }

        private static void OnProductModelPropertyChanged(OrderEditorViewModel orderEditorViewModel, object o,
            PropertyChangedEventArgs arg3)
        {
            orderEditorViewModel.HasChanges = true;
            orderEditorViewModel.OnPropertyChanged("HasChanges");
        }

        private bool Filter(SelectableWrapper<ProductModel> item)
        {
            if (item == null)
                return false;
            if (string.IsNullOrWhiteSpace(FilterText))
                return true;
            return item.Model.Name.SafeContains(FilterText) || item.Model.Description.SafeContains(FilterText);
        }

        #endregion

        #region Implementation of interfaces

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (value == _displayName) return;
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public async void LoadState(IDataContext state)
        {
            var viewModelState = state.GetData(StateConstant);
            if (viewModelState == null)
                return;
            InitializeEntity(viewModelState.Order, viewModelState.IsNewRecord);
            await _initializedTask;

            _oldLinks = viewModelState.Links;
            RestoreSelection(viewModelState.SelectedProducts);
            HasChanges = true;
        }

        public void SaveState(IDataContext state)
        {
            if (!IsEntityInitialized)
                return;
            var viewModelState = new ViewModelState { Order = Entity, IsNewRecord = IsNewRecord };
            if (_oldLinks != null)
                viewModelState.Links = _oldLinks;
            var selectedProducts = GridViewModel.OriginalItemsSource
                .Where(wrapper => wrapper.IsSelected)
                .Select(wrapper => wrapper.Model.Id)
                .ToList();
            viewModelState.SelectedProducts = selectedProducts;
            state.AddOrUpdate(StateConstant, viewModelState);
        }

        #endregion

        #region Overrides of EditableViewModel<ProductModel>

        protected override void OnEntityInitialized()
        {
            DisplayName = IsNewRecord ? UiResources.OrderNewDisplayName : UiResources.OrderEditDisplayName;
            _initializedTask = _repository
                .GetProductsAsync(DisposeCancellationToken)
                .TryExecuteSynchronously(task =>
                {
                    foreach (ProductModel productModel in task.Result)
                    {
                        var item = new SelectableWrapper<ProductModel>(false, productModel);
                        item.PropertyChanged += _propertyChangedEventHandler;
                        GridViewModel.OriginalItemsSource.Add(item);
                    }
                    if (_oldLinks != null)
                        RestoreSelection(_oldLinks.Select(model => model.IdProduct).ToList());
                })
                .WithBusyIndicator(this);
        }

        protected override IList<IEntityStateEntry> GetChanges(OrderModel entity)
        {
            var changes = new List<IEntityStateEntry>(base.GetChanges(entity));
            List<ProductModel> selectedItems = GridViewModel
                .OriginalItemsSource
                .Where(wrapper => wrapper.IsSelected)
                .Select(wrapper => wrapper.Model)
                .ToList();
            var oldLinks = new List<OrderProductModel>(_oldLinks ?? Empty.Array<OrderProductModel>());

            //Adding new items that was selected.
            foreach (ProductModel selectedItem in selectedItems)
            {
                OrderProductModel oldItem = oldLinks.SingleOrDefault(model => model.IdOrder == selectedItem.Id);
                if (oldItem == null)
                {
                    var productModel = new OrderProductModel
                    {
                        IdOrder = Entity.Id,
                        IdProduct = selectedItem.Id
                    };
                    changes.Add(new EntityStateEntry(EntityState.Added, productModel));
                }
                else
                    oldLinks.Remove(oldItem);
            }

            //Removing old items that was unselected.
            changes.AddRange(oldLinks.Select(model => new EntityStateEntry(EntityState.Deleted, model)));
            return changes;
        }

        protected override bool IsValidInternal()
        {
            return base.IsValidInternal() && GridViewModel != null && GridViewModel.OriginalItemsSource != null &&
                   GridViewModel.OriginalItemsSource.Any(wrapper => wrapper.IsSelected);
        }

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<SelectableWrapper<ProductModel>>>();
            GridViewModel.Filter = Filter;
            if (IsDesignMode)
                InitializeEntity(new OrderModel(), true);
        }

        #endregion
    }
}