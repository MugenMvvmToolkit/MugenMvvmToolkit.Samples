using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class BindingExpressionActivityView : MvvmActivity
    {
        public BindingExpressionActivityView()
            : base(Resource.Layout.BindingExpressionView)
        {
        }
    }
}