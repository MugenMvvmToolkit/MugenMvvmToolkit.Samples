#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace ApiExamples.Views
{
    public class ItemFragmentView : MvvmFragment
    {
        #region Constructors

        public ItemFragmentView()
            : base(Resource.Layout.ItemView)
        {
        }

        #endregion
    }
}