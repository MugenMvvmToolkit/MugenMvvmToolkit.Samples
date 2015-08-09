using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
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