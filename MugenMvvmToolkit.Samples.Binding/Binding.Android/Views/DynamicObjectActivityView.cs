using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class DynamicObjectActivityView : MvvmActivity
    {
        public DynamicObjectActivityView()
            : base(Resource.Layout.DynamicObjectView)
        {
        }
    }
}