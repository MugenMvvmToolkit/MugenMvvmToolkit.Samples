using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace OrderManager.Android.Views.Orders
{
    [Activity(Label = "OrderManager.Android")]
    public class OrderWorkspaceActivityView : MvvmActivity
    {
        public OrderWorkspaceActivityView()
            : base(Resource.Layout.OrderWorkspaceView)
        {
        }
    }
}