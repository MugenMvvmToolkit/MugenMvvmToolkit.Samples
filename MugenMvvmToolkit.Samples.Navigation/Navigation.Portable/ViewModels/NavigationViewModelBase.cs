using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public abstract class NavigationViewModelBase : WorkspaceViewModel
    {
        #region Constructors

        protected NavigationViewModelBase(IMessagePresenter messagePresenter)
        {
            MessagePresenter = messagePresenter;
            DisplayName = GetType().Name;
            ShowOpenedViewModelsCommand = new AsyncRelayCommand(ShowOpenedViewModelsAsync, false);
        }

        #endregion

        #region Properties

        public ICommand ShowOpenedViewModelsCommand { get; }

        protected IMessagePresenter MessagePresenter { get; }

        #endregion

        #region Methods

        private async Task ShowOpenedViewModelsAsync()
        {
            using (var vm = GetViewModel<OpenedViewModelsViewModel>())
                await vm.ShowAsync();
        }

        protected async Task<bool> ShowCloseQuestionAsync(string name)
        {
            return await MessagePresenter.ShowAsync($"Are you sure, you want to close the {name} view model?", "Closing", MessageButton.YesNo) == MessageResult.Yes;
        }

        #endregion
    }
}