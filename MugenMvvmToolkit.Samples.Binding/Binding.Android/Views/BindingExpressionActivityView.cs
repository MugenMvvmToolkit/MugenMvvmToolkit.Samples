using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingExpressionActivityView : MvvmAppCompatActivity
    {
        public BindingExpressionActivityView()
            : base(Resource.Layout.BindingExpressionView)
        {
        }
    }
}