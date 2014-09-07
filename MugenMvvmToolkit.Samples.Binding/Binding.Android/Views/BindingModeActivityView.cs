using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingModeActivityView : MvvmActivity
    {
        public BindingModeActivityView()
            : base(Resource.Layout.BindingModeView)
        {
        }
    }
}