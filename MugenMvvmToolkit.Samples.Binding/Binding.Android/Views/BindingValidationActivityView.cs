using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingValidationActivityView : MvvmAppCompatActivity
    {
        public BindingValidationActivityView()
            : base(Resource.Layout.BindingValidationView)
        {
        }
    }
}