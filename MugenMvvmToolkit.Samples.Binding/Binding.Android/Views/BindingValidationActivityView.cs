using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingValidationActivityView : MvvmActivity
    {
        public BindingValidationActivityView()
            : base(Resource.Layout.BindingValidationView)
        {
        }
    }
}