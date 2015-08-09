using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace OrderManager.Android.Views
{
    [Activity(Label = "OrderManager.Android", Icon = "@drawable/icon")]
    public class MainActivity : MvvmAppCompatActivity
    {
        public MainActivity()
            : base(Resource.Layout.MainView)
        {
        }
    }
}