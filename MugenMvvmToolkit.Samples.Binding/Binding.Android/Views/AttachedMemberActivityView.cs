using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class AttachedMemberActivityView : MvvmAppCompatActivity
    {
        public AttachedMemberActivityView()
            : base(Resource.Layout.AttachedMemberView)
        {
        }
    }
}