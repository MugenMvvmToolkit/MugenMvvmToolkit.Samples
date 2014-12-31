#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace OrderManager.Android.Views.Orders
{
    public class OrderEditorFragmentView : MvvmFragment
    {
        public OrderEditorFragmentView()
            : base(Resource.Layout.OrderEditorView)
        {
        }
    }
}