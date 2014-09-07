using Binding.Portable.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class DynamicObjectViewModel : CloseableViewModel
    {
        #region Constructors

        public DynamicObjectViewModel()
        {
            DynamicModel = new DynamicModel();
            if (IsDesignMode)
                DynamicModel.SetMember("DynamicProperty", new object[] { "Design text" });
        }

        #endregion

        #region Properties

        public DynamicModel DynamicModel { get; private set; }

        #endregion
    }
}