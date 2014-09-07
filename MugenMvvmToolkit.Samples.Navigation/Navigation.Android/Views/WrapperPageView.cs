using Android.App;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Navigation.Android.Views
{
#if API8
    [Activity(Label = "Navigation.Android", Theme = "@style/Theme.AppCompat")]
#else
    [Activity(Label = "Navigation.Android")]
#endif
    public class WrapperPageView : MvvmActivity
    {
        public WrapperPageView()
            : base(Resource.Layout.WrapperView)
        {
        }
    }
}