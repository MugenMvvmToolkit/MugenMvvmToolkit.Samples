using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class RelativeBindingActivityView : MvvmAppCompatActivity
    {
        public RelativeBindingActivityView()
            : base(Resource.Layout.RelativeBindingView)
        {
        }
    }
}