using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class ListDataTemplateViewModel : ViewModelBase
    {
        #region Fields

        private GridViewModel<ListItemModel> _gridViewModel;

        #endregion

        #region Constructors

        public ListDataTemplateViewModel()
        {
            AddCommand = new RelayCommand<bool>(Add);
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; private set; }

        private void Add(bool param)
        {
            var model = new ListItemModel { IsValid = param };
            GridViewModel.ItemsSource.Add(model);
            GridViewModel.SelectedItem = model;
        }

        #endregion

        #region Properties

        public GridViewModel<ListItemModel> GridViewModel
        {
            get { return _gridViewModel; }
            private set
            {
                _gridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<ListItemModel>>();
            GridViewModel.ItemsSource.Add(new ListItemModel { IsValid = true });
            GridViewModel.ItemsSource.Add(new ListItemModel { IsValid = false });
        }

        #endregion
    }
}