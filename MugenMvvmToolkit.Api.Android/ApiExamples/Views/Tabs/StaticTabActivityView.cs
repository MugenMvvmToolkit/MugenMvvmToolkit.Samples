using Android.App;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Tabs
{
#if API8
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat")]    
#else
    [Activity(Label = "ApiExamples")]
#endif
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