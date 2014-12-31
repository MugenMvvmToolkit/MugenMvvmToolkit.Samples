using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Tabs
{
    [Activity(Label = "ApiExamples")]
    public class StaticTabActivityView : MvvmActivity
    {
        #region Constructors

        public StaticTabActivityView()
            : base(Resource.Layout.ActionBarStaticTabView)
        {
        }

        #endregion
    }
}