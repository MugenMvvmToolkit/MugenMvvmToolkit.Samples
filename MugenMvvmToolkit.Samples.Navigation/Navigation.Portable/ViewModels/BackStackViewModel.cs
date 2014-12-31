using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class BackStackViewModel : CloseableViewModel, IHasState
    {
        #region Fields

        private int _depth;

        #endregion

        #region Constructors

        public BackStackViewModel()
        {
            Depth = 1;
            NavigateCommand = new RelayCommand(Navigate);
            NavigateClearBackStackCommand = new RelayCommand(NavigateClearBackStack);
        }

        #endregion

        #region Commands

        public ICommand NavigateCommand { get; private set; }

        public ICommand NavigateClearBackStackCommand { get; private set; }

        private async void NavigateClearBackStack(object o)
        {
            using (var vm = GetViewModel<MainViewModel>())
                await vm.ShowAsync(NavigationConstants.ClearBackStack.ToValue(true));
        }

        private async void Navigate(object o)
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

        /// <summary>
        ///     Loads state.
        /// </summary>
        public void LoadState(IDataContext state)
        {
            int data;
            if (state.TryGetData("Depth", out data))
                Depth = data;
        }

        /// <summary>
        ///     Saves state.
        /// </summary>
        public void SaveState(IDataContext state)
        {
            state.AddOrUpdate("Depth", Depth);
        }

        #endregion
    }
}