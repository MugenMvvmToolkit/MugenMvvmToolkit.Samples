using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class CollectionBindingActivityView : MvvmAppCompatActivity
    {
        public CollectionBindingActivityView()
            : base(Resource.Layout.CollectionBindingView)
        {
        }
    }
}