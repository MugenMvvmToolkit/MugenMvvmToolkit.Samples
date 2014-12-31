#if APPCOMPAT
using MugenMvvmToolkit.AppCompat.Views.Fragments;
#else
using MugenMvvmToolkit.FragmentSupport.Views.Fragments;
#endif


namespace OrderManager.Android.Views.Products
{
    public class ProductEditorFragmentView : MvvmFragment
    {
        public ProductEditorFragmentView()
            : base(Resource.Layout.ProductEditorView)
        {
        }
    }
}