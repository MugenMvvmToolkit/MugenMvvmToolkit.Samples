using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class RelativeBindingActivityView : MvvmActivity
    {
        public RelativeBindingActivityView()
            : base(Resource.Layout.RelativeBindingView)
        {
        }
    }
}