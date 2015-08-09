using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace OrderManager.Android.Views.Orders
{
    [Activity(Label = "OrderManager.Android")]
    public class OrderWorkspaceActivityView : MvvmAppCompatActivity
    {
        public OrderWorkspaceActivityView()
            : base(Resource.Layout.OrderWorkspaceView)
        {
        }
    }
}