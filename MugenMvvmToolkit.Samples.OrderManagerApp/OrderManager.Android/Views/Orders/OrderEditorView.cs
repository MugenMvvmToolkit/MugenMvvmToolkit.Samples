using MugenMvvmToolkit.Views;
#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace OrderManager.Android.Views.Orders
{
    public class OrderEditorView : UserControl //you can use MvvmFragment instead of UserControl, but UserControl is lighter than the Fragment.
    {
        public OrderEditorView()
            : base(Resource.Layout.OrderEditorView)
        {
        }
    }
}