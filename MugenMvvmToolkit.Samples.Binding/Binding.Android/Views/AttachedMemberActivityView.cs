using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class AttachedMemberActivityView : MvvmActivity
    {
        public AttachedMemberActivityView()
            : base(Resource.Layout.AttachedMemberView)
        {
        }
    }
}