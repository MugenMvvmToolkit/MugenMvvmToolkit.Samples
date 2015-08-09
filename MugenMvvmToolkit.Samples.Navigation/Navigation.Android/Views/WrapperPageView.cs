using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class WrapperPageView : MvvmAppCompatActivity
    {
        public WrapperPageView()
            : base(Resource.Layout.WrapperView)
        {
        }
    }
}