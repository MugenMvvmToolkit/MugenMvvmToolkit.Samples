using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace OrderManager.Android.Views
{
    [Activity(Label = "OrderManager.Android")]
    public class EditorWrapperActivityView : MvvmActivity
    {
        public EditorWrapperActivityView()
            : base(Resource.Layout.EditorWrapperView)
        {
        }
    }
}