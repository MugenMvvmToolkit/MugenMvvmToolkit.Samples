using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace OrderManager.Android.Views.Products
{
    [Activity(Label = "OrderManager.Android")]
    public class ProductWorkspaceActivityView : MvvmAppCompatActivity
    {
        public ProductWorkspaceActivityView()
            : base(Resource.Layout.ProductWorkspaceView)
        {
        }
    }
}