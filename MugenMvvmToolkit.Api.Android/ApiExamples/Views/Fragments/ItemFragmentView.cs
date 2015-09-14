using MugenMvvmToolkit;
#if APPCOMPAT
using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.Android.Views.Fragments;
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