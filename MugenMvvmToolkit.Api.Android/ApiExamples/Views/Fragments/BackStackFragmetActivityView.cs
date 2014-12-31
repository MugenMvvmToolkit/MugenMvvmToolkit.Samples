using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Fragments
{
    [Activity(Label = "ApiExamples")]
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