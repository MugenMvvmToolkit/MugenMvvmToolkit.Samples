using MugenMvvmToolkit.Android.Views;
using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;

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