using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class ResultViewModel : NavigationViewModelBase, IHasResultViewModel<string>, IHasState
    {
        #region Fields

        private string _result = "Default result";

        #endregion

        #region Constructors

        public ResultViewModel(IMessagePresenter messagePresenter) : base(messagePresenter)
        {
        }

        #endregion

        #region Properties

        public string Result
        {
            get { return _result; }
            set
            {
                if (value == _result) return;
                _result = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Implementation of interfaces

        void IHasState.LoadState(IDataContext state)
        {
            Result = state.GetData<string>(nameof(Result));
        }

        void IHasState.SaveState(IDataContext state)
        {
            if (!string.IsNullOrEmpty(Result))
                state.AddOrUpdate(nameof(Result), Result);
        }

        #endregion
    }
}