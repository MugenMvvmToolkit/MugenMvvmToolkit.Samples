using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views.Menus
{
    [Activity(Label = "ApiExamples")]
    public class NavigationActivityView : MvvmActivity
    {
        #region Constructors

        public NavigationActivityView()
            : base(Resource.Layout.NavigationView)
        {
        }

        #endregion
    }
}