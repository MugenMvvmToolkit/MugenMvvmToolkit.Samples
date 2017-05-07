using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;

namespace Navigation.Portable.ViewModels
{
    public class TabViewModel : NavigationViewModelBase, IHasState
    {
        #region Fields

        private static int _counter;

        #endregion

        #region Constructors

        public TabViewModel(IMessagePresenter messagePresenter) : base(messagePresenter)
        {
            DisplayName = "Tab " + ++_counter;
            Text = "Tab view model " + _counter;
        }

        #endregion

        #region Properties

        public string Text { get; private set; }

        #endregion

        #region Methods

        protected override Task<bool> OnClosing(IDataContext context)
        {
            return ShowCloseQuestionAsync(DisplayName);
        }

        #endregion

        #region Implementation of interfaces

        void IHasState.LoadState(IDataContext state)
        {
            DisplayName = state.GetData<string>(nameof(DisplayName));
            Text = state.GetData<string>(nameof(Text));
        }

        void IHasState.SaveState(IDataContext state)
        {
            state.AddOrUpdate(nameof(Text), Text);
            state.AddOrUpdate(nameof(DisplayName), DisplayName);
        }

        #endregion
    }
}