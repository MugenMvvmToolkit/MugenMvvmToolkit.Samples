using MugenMvvmToolkit.Android.Views;
using MugenMvvmToolkit.Android.AppCompat.Views.Fragments;

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