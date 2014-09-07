using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace OrderManager.Android.Views.Products
{
    [Activity(Label = "OrderManager.Android")]
    public class ProductWorkspaceActivityView : MvvmActivity
    {
        public ProductWorkspaceActivityView()
            : base(Resource.Layout.ProductWorkspaceView)
        {
        }
    }
}