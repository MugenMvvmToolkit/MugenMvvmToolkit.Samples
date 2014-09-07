using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android", Icon = "@drawable/icon")]
    public class MainActivity : MvvmActivity
    {
        public MainActivity()
            : base(Resource.Layout.Main)
        {
        }
    }
}