using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class CommandBindingActivityView : MvvmAppCompatActivity
    {
        public CommandBindingActivityView()
            : base(Resource.Layout.CommandBindingView)
        {
        }
    }
}