using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

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