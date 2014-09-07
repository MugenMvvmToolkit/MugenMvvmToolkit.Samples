using Android.App;
using MugenMvvmToolkit.Views.Activities;

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