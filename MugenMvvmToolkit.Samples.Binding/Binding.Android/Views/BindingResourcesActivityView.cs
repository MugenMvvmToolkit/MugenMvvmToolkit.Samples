using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingResourcesActivityView : MvvmAppCompatActivity
    {
        public BindingResourcesActivityView()
            : base(Resource.Layout.BindingResourcesView)
        {
        }
    }
}