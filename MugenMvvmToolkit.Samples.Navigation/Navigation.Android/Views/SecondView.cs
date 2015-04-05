using MugenMvvmToolkit.Views;
#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace Navigation.Android.Views
{
    public class SecondView : UserControl //you can use MvvmFragment instead of UserControl, but UserControl is lighter than the Fragment.
    {
        public SecondView()
            : base(Resource.Layout.SecondView)
        {
        }
    }
}