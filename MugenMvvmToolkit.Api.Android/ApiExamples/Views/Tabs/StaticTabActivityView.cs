using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
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