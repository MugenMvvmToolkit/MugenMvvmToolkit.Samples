using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android", Icon = "@drawable/icon")]
    public class MainActivity : MvvmAppCompatActivity
    {
        public MainActivity()
            : base(Resource.Layout.Main)
        {
        }
    }
}