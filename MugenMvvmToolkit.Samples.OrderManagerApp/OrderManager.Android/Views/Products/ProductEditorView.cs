using MugenMvvmToolkit.Views;
#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif

namespace OrderManager.Android.Views.Products
{
    public class ProductEditorView : UserControl //you can use MvvmFragment instead of UserControl, but UserControl is lighter than the Fragment.
    {
        public ProductEditorView()
            : base(Resource.Layout.ProductEditorView)
        {
        }
    }
}