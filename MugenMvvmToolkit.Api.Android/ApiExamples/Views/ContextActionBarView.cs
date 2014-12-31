using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
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