using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.ViewModels.Products
{
    public class ProductEditorViewModel : EditableViewModel<ProductModel>, IHasDisplayName, IHasState
    {
        #region Fields

        private string _displayName;

        private static readonly DataConstant<ProductModel> EntityConstant;
        private static readonly DataConstant<bool> IsNewRecordConstant;

        #endregion

        #region Constructors

        static ProductEditorViewModel()
        {
            EntityConstant = DataConstant.Create(() => EntityConstant, true);
            IsNewRecordConstant = DataConstant.Create(() => IsNewRecordConstant);
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                if (Equals(Entity.Name, value))
                    return;
                Entity.Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return Entity.Description; }
            set
            {
                if (Equals(Entity.Description, value))
                    return;
                Entity.Description = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return Entity.Price; }
            set
            {
                if (Equals(Entity.Price, value))
                    return;
                Entity.Price = value;
                OnPropertyChanged();
            }
        }

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

        #endregion

        #region Implementation of interfaces

        public void LoadState(IDataContext state)
        {
            var data = state.GetData(EntityConstant);
            if (data == null)
                return;
            var isNew = state.GetData(IsNewRecordConstant);
            InitializeEntity(data, isNew);
            HasChanges = true;
        }

        public void SaveState(IDataContext state)
        {
            if (!IsEntityInitialized)
                return;
            state.AddOrUpdate(EntityConstant, Entity);
            state.AddOrUpdate(IsNewRecordConstant, IsNewRecord);
        }

        #endregion

        #region Overrides of EditableViewModel<ProductModel>

        protected override void OnEntityInitialized()
        {
            DisplayName = IsNewRecord ? UiResources.ProductNewDisplayName : UiResources.ProductEditDisplayName;
        }

        protected override void OnInitialized()
        {
            if (IsDesignMode)
                InitializeEntity(new ProductModel(), true);
        }

        #endregion
    }
}