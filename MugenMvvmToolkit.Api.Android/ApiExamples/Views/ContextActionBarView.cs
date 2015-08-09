using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    public class ContextActionBarView : MvvmActivity
    {
        #region Constructors

        public ContextActionBarView()
            : base(Resource.Layout.ContextActionBarView)
        {
        }

        #endregion
    }
}