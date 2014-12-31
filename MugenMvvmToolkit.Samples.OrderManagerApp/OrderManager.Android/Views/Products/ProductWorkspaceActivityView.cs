using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

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