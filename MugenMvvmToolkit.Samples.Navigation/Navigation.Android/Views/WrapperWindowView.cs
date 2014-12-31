#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace Navigation.Android.Views
{
    public class WrapperWindowView : MvvmDialogFragment
    {
        public WrapperWindowView()
            : base(Resource.Layout.WrapperView)
        {
        }
    }
}