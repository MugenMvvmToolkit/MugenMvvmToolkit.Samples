using System.Windows.Input;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels.Tabs
{
    public class TabViewModel : MultiViewModel<ItemViewModel>
    {
        #region Constructors

        public TabViewModel()
        {
            AddCommand = new RelayCommand(Add);
            InsertCommand = new RelayCommand(Insert, CanInsert, this);
            RemoveCommand = new RelayCommand(Remove, CanRemove, this);
        }

        #endregion

        #region Methods

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            for (var i = 0; i < 4; i++)
            {
                var itemViewModel = GetViewModel<ItemViewModel>();
                itemViewModel.Name = "Default item";
                ItemsSource.Add(itemViewModel);
            }
            SelectedItem = ItemsSource[0];
        }

        #endregion

        #endregion

        #region Commands

        public ICommand AddCommand { get; }

        public ICommand InsertCommand { get; }

        public ICommand RemoveCommand { get; }

        private void Add()
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic item";
            AddViewModel(itemViewModel);
            SelectedItem = itemViewModel;
        }

        private bool CanRemove()
        {
            return SelectedItem != null;
        }

        private void Remove()
        {
            RemoveViewModelAsync(SelectedItem);
        }

        private bool CanInsert()
        {
            return SelectedItem != null;
        }

        private void Insert()
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic item";
            var selectedIndex = ItemsSource.IndexOf(SelectedItem);
            ItemsSource.Insert(selectedIndex, itemViewModel);
            SelectedItem = itemViewModel;
        }

        #endregion
    }
}