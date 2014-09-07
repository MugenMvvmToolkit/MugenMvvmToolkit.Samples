using Android.App;
using MugenMvvmToolkit.Views.Activities;

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