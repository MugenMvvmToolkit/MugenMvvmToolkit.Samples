using MugenMvvmToolkit.Android.Views;
using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;

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