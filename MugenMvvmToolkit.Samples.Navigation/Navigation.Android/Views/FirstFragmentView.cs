#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace Navigation.Android.Views
{
    public class FirstFragmentView : MvvmFragment
    {
        public FirstFragmentView()
            : base(Resource.Layout.FirstView)
        {
        }
    }
}