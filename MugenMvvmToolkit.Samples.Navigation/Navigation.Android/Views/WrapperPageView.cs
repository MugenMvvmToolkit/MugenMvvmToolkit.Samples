using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class WrapperPageView : MvvmActivity
    {
        public WrapperPageView()
            : base(Resource.Layout.WrapperView)
        {
        }
    }
}