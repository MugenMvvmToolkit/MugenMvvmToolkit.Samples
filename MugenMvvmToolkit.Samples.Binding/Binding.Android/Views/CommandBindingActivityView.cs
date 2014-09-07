using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class CommandBindingActivityView : MvvmActivity
    {
        public CommandBindingActivityView()
            : base(Resource.Layout.CommandBindingView)
        {
        }
    }
}