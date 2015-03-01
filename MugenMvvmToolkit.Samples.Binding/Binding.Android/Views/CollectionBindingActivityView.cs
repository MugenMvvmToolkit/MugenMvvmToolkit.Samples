using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class CollectionBindingActivityView : MvvmActivity
    {
        public CollectionBindingActivityView()
            : base(Resource.Layout.CollectionBindingView)
        {
        }
    }
}