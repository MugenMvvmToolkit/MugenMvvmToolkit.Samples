using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class BackStackViewModel : CloseableViewModel, IHasState, INavigableViewModel
    {
        #region Fields

        private int _depth;

        #endregion

        #region Constructors

        public BackStackViewModel()
        {
            Depth = 1;
            NavigateCommand = RelayCommandBase.FromAsyncHandler(Navigate);
            NavigateClearBackStackCommand = RelayCommandBase.FromAsyncHandler(NavigateClearBackStack);
        }

        #endregion

        #region Commands

        public ICommand NavigateCommand { get; private set; }

        public ICommand NavigateClearBackStackCommand { get; private set; }

        private async Task NavigateClearBackStack()
        {
            using (var vm = GetViewModel<MainViewModel>())
                await vm.ShowAsync(NavigationConstants.ClearBackStack.ToValue(true));
        }

        private async Task Navigate()
        {
            using (var vm = GetViewModel<BackStackViewModel>())
            {
                vm.Depth += Depth;
                await vm.ShowAsync();
            }
        }

        #endregion

        #region Properties

        public int Depth
        {
            get { return _depth; }
            set
            {
                if (value == _depth)
                    return;
                _depth = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Implementation of IHasState

        public void LoadState(IDataContext state)
        {
            int data;
            if (state.TryGetData("Depth", out data))
                Depth = data;
        }

        public void SaveState(IDataContext state)
        {
            state.AddOrUpdate("Depth", Depth);
        }

        #endregion

        #region Implementation of INavigableViewModel

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            this.TraceNavigation();
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            this.TraceNavigation();
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
            this.TraceNavigation();
        }

        #endregion
    }
}