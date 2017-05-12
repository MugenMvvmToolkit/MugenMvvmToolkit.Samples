using System.Threading.Tasks;
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
            ShowAnnotationCommand = RelayCommandBase.FromAsyncHandler(ShowAnnotation);
            ShowUserEditorCommand = RelayCommandBase.FromAsyncHandler(ShowUserEditor);
        }

        #endregion

        #region Properties

        public ICommand ShowAnnotationCommand { get; }

        public ICommand ShowUserEditorCommand { get; }

        #endregion

        #region Methods

        private async Task ShowAnnotation()
        {
            var model = new ValidatableModel();
            using (var viewModel = GetViewModel<DataAnnotationViewModel>())
            {
                viewModel.Model = model;
                viewModel.AddInstance(model);
                await viewModel.ShowAsync();
            }
        }

        private async Task ShowUserEditor()
        {
            using (var viewModel = GetViewModel<UserWorkspaceViewModel>())
            {
                await viewModel.ShowAsync();
            }
        }

        #endregion
    }
}