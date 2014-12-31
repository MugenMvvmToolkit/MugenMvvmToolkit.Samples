using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace OrderManager.Android.Views
{
    [Activity(Label = "OrderManager.Android", Icon = "@drawable/icon")]
    public class MainActivity : MvvmActivity
    {
        public MainActivity()
            : base(Resource.Layout.MainView)
        {
        }
    }
}