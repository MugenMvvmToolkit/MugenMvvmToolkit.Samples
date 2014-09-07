using Android.App;
using MugenMvvmToolkit.Views.Activities;

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