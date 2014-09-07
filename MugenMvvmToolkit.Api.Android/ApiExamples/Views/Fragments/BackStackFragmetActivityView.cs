using Android.App;
using Android.OS;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Fragments
{
#if API8
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat")]    
#else
    [Activity(Label = "ApiExamples")]
#endif
    public class BackStackFragmetActivityView : MvvmActivity
    {
        #region Constructors

        public BackStackFragmetActivityView()
            : base(Resource.Layout.BackStackFragmetView)
        {
        }

        #endregion
    }
}