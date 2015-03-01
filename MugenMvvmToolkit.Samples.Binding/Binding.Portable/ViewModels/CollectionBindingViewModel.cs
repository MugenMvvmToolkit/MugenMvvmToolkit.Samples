using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Binding.Portable.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class CollectionBindingViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _filterText;

        #endregion

        #region Constructors

        public CollectionBindingViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand<CollectionItemModel>(Remove, CanRemove, this);
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        private void Add(object o)
        {
            int id = GridViewModel.OriginalItemsSource.Max(model => model.Id) + 1;
            var newItem = new CollectionItemModel { Id = id, Name = "Added item" };
            GridViewModel.ItemsSource.Add(newItem);
            GridViewModel.SelectedItem = newItem;
        }

        private async void Remove(CollectionItemModel item)
        {
            if (item == null)
                item = GridViewModel.SelectedItem;
            if (await _messagePresenter.ShowAsync(string.Format("Delete {0} {1}?", item.Name, item.Id), "Delete", MessageButton.YesNo) == MessageResult.Yes)
            {
                GridViewModel.ItemsSource.Remove(item);
                GridViewModel.SelectedItem = null;
            }
        }

        private bool CanRemove(CollectionItemModel item)
        {
            return item != null || (GridViewModel != null && GridViewModel.SelectedItem != null);
        }

        #endregion

        #region Properties

        public GridViewModel<CollectionItemModel> GridViewModel { get; private set; }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (value == _filterText)
                    return;
                _filterText = value;
                GridViewModel.UpdateFilter();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<CollectionItemModel>>();
            for (int i = 0; i < 200; i++)
                GridViewModel.ItemsSource.Add(new CollectionItemModel { Name = "Item", Id = i });
            GridViewModel.Filter = Filter;
        }

        #endregion

        #region Methods

        private bool Filter(CollectionItemModel item)
        {
            if (string.IsNullOrEmpty(FilterText))
                return true;
            return item != null &&
                   (item.Name.SafeContains(FilterText) ||
                    item.Id.ToString(CultureInfo.InvariantCulture).SafeContains(FilterText));
        }

        #endregion
    }
}