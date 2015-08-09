using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingModeActivityView : MvvmAppCompatActivity
    {
        public BindingModeActivityView()
            : base(Resource.Layout.BindingModeView)
        {
        }
    }
}