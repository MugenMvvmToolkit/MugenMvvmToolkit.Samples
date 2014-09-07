using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingResourcesActivityView : MvvmActivity
    {
        public BindingResourcesActivityView()
            : base(Resource.Layout.BindingResourcesView)
        {
        }
    }
}