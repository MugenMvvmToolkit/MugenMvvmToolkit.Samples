using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class DynamicObjectActivityView : MvvmAppCompatActivity
    {
        public DynamicObjectActivityView()
            : base(Resource.Layout.DynamicObjectView)
        {
        }
    }
}