using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;

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