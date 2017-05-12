using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TableViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _filterText;
        private GridViewModel<TableItemModel> _gridViewModel;

        #endregion

        #region Constructors

        public TableViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            _messagePresenter = messagePresenter;
            AddCommand = new RelayCommand(Add);
            ItemClickCommand = new RelayCommand<TableItemModel>(ItemClick);
            RemoveCommand = new RelayCommand<TableItemModel>(Remove, CanRemove, this);
            InvertSelectionCommand = new RelayCommand(InvertSelection);
        }

        #endregion

        #region Properties

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (Equals(value, _filterText))
                    return;
                _filterText = value;
                OnPropertyChanged();
                GridViewModel?.UpdateFilter();
            }
        }

        public GridViewModel<TableItemModel> GridViewModel
        {
            get { return _gridViewModel; }
            private set
            {
                _gridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ItemClickCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand InvertSelectionCommand { get; }

        private void Add(object o)
        {
            var id = GridViewModel.OriginalItemsSource.Max(model => model.Id) + 1;
            var newItem = new TableItemModel {Id = id, Name = "Added item " + id};
            GridViewModel.ItemsSource.Add(newItem);
            GridViewModel.SelectedItem = newItem;
        }

        private void ItemClick(TableItemModel obj)
        {
            _messagePresenter.ShowAsync(obj.Name, "Clicked");
        }

        private async void Remove(TableItemModel item)
        {
            if (item == null)
                item = GridViewModel.SelectedItem;
            if (await _messagePresenter.ShowAsync("Are you sure, you want to delete the '" + item.Name + "' ?", "Delete", MessageButton.YesNo) !=
                MessageResult.Yes)
                return;
            GridViewModel.ItemsSource.Remove(item);
        }

        private bool CanRemove(TableItemModel item)
        {
            return item != null || GridViewModel.SelectedItem != null;
        }

        private void InvertSelection(object o)
        {
            foreach (var model in GridViewModel.OriginalItemsSource)
                model.IsSelected = !model.IsSelected;
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<TableItemModel>>();
            GridViewModel.Filter = Filter;
            for (var i = 0; i < 100; i++)
            {
                GridViewModel.ItemsSource.Add(new TableItemModel
                {
                    Id = i,
                    Name = "Item " + i.ToString(CultureInfo.InvariantCulture)
                });
            }
        }

        private bool Filter(TableItemModel item)
        {
            if (string.IsNullOrEmpty(FilterText))
                return true;
            return item.Name.SafeContains(FilterText);
        }

        #endregion
    }
}