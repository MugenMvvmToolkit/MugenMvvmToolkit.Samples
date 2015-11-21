using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Callbacks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;

namespace SplitView.Portable.ViewModels
{
    public class BackStackMainViewModel : SelectedItemMainViewModel
    {
        #region Nested Types

        //NOTE we cannot use default list, because MONO cannot deserialize it correctly.
        [DataContract(Namespace = ApplicationSettings.DataContractNamespace, IsReference = true)]
        internal sealed class StateList
        {
            #region Fields

            [DataMember]
            public List<IDataContext> State;

            #endregion
        }

        #endregion

        #region Fields

        private static readonly DataConstant<StateList> ViewModelsState;

        private readonly Stack<IViewModel> _viewModels;

        #endregion

        #region Constructors

        static BackStackMainViewModel()
        {
            ViewModelsState = DataConstant.Create(() => ViewModelsState, true);
        }

        public BackStackMainViewModel(IViewModelPresenter presenter, IOperationCallbackManager callbackManager, IToastPresenter toastPresenter)
            : base(presenter, callbackManager, toastPresenter)
        {
            _viewModels = new Stack<IViewModel>();
        }

        #endregion

        #region Methods

        public override void LoadState(IDataContext state)
        {
            var stateList = state.GetData(ViewModelsState);
            if (stateList == null)
                return;
            for (var i = 0; i < stateList.State.Count; i++)
            {
                var viewModel = ViewModelProvider.RestoreViewModel(stateList.State[i], null, true);
                _viewModels.Push(viewModel);
            }
            SelectedItem = _viewModels.Peek();
        }

        public override void SaveState(IDataContext state)
        {
            if (_viewModels.Count == 0)
                return;
            var states = new List<IDataContext>();
            foreach (var viewModel in _viewModels)
                states.Insert(0, ViewModelProvider.PreserveViewModel(viewModel, null));
            state.AddOrUpdate(ViewModelsState, new StateList { State = states });
        }

        protected override Task<bool> OnClosing(object parameter)
        {
            if (_viewModels.Count == 0)
                return base.OnClosing(parameter);

            //Invoke close callback
            InvokeCloseCallback(_viewModels.Pop());
            SelectedItem = _viewModels.Count == 0 ? null : _viewModels.Peek();
            return Empty.FalseTask;
        }

        protected override void OnShowViewModel(IViewModel viewModel)
        {
            _viewModels.Push(viewModel);
            SelectedItem = viewModel;
        }

        #endregion
    }
}