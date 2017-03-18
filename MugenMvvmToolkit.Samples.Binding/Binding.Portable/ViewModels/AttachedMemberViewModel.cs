using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class AttachedMemberViewModel : CloseableViewModel
    {
        #region Constructors

        public AttachedMemberViewModel()
        {
            ImageUrl = "https://raw.githubusercontent.com/MugenMvvmToolkit/MugenMvvmToolkit/master/logo_horizontal.png";
        }

        #endregion

        #region Properties

        public string ImageUrl { get; }

        #endregion
    }
}