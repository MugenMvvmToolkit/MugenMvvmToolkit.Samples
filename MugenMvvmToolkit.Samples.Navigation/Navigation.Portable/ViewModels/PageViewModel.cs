using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class PageViewModel : NavigationViewModelBase, IHasState
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private string _text;
        private static int _counter;

        #endregion

        #region Constructors

        public PageViewModel(IMessagePresenter messagePresenter, IToastPresenter toastPresenter) : base(messagePresenter)
        {
            _toastPresenter = toastPresenter;
            Text = "Page view model " + Interlocked.Increment(ref _counter);
            DisplayName = Text;
            ToNextPageCommand = new AsyncRelayCommand(ToNextPageAsync, false);
        }

        #endregion

        #region Properties

        public ICommand ToNextPageCommand { get; }

        public string Text
        {
            get { return _text; }
            private set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private async Task ToNextPageAsync()
        {
            using (var viewModel = GetViewModel<PageViewModel>())
            {
                await viewModel.ShowAsync();
                _toastPresenter.ShowAsync($"The '{viewModel.Text}' is closed.", ToastDuration.Short);
            }
        }

        protected override Task<bool> OnClosing(IDataContext context)
        {
            return ShowCloseQuestionAsync("page");
        }

        #endregion

        #region Implementation of interfaces

        void IHasState.LoadState(IDataContext state)
        {
            Text = state.GetData<string>(nameof(Text));
        }

        void IHasState.SaveState(IDataContext state)
        {
            state.AddOrUpdate(nameof(Text), Text);
        }

        #endregion
    }
}