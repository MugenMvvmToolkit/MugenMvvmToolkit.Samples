using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Validation.Portable.Models;

namespace Validation.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Constructors

        public MainViewModel()
        {
            ShowAnnotationCommand = new RelayCommand(ShowAnnotation);
            ShowUserEditorCommand = new RelayCommand(ShowUserEditor);
        }

        #endregion

        #region Properties

        public ICommand ShowAnnotationCommand { get; private set; }

        public ICommand ShowUserEditorCommand { get; private set; }

        #endregion

        #region Methods

        private async void ShowAnnotation(object obj)
        {
            var model = new ValidatableModel();
            using (var viewModel = GetViewModel<DataAnnotationViewModel>())
            {
                viewModel.Model = model;
                viewModel.AddInstance(model);
                await viewModel.ShowAsync();
            }
        }

        private async void ShowUserEditor(object obj)
        {
            using (var viewModel = GetViewModel<UserWorkspaceViewModel>())
                await viewModel.ShowAsync();
        }

        #endregion
    }
}