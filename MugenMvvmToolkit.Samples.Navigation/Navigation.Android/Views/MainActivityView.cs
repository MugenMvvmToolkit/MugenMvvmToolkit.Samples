using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class MainActivity : MvvmActivity
    {
        public MainActivity()
            : base(Resource.Layout.Main)
        {
        }
    }
}