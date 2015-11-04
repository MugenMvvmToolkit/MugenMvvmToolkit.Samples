using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace SplitView.Portable.ViewModels
{
    public class ItemViewModel : WorkspaceViewModel, IHasState
    {
        #region Properties

        public int Id { get; set; }

        #endregion

        #region Implementation of interfaces

        public void LoadState(IDataContext state)
        {
            DisplayName = state.GetData<string>("Name");
            Id = state.GetData<int>("Id");
        }

        public void SaveState(IDataContext state)
        {
            state.AddOrUpdate("Name", DisplayName);
            state.AddOrUpdate("Id", Id);
        }

        #endregion
    }
}