#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace Navigation.Android.Views
{
    public class SecondFragmentView : MvvmFragment
    {
        public SecondFragmentView()
            : base(Resource.Layout.SecondView)
        {
        }
    }
}