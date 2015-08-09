using MugenMvvmToolkit.Android.Views;
using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;

namespace Navigation.Android.Views
{
    public class FirstView : UserControl //you can use MvvmFragment instead of UserControl, but UserControl is lighter than the Fragment.
    {
        public FirstView()
            : base(Resource.Layout.FirstView)
        {
        }
    }
}