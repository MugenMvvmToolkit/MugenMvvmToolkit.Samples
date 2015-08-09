using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class MainActivity : MvvmAppCompatActivity
    {
        public MainActivity()
            : base(Resource.Layout.Main)
        {
        }
    }
}