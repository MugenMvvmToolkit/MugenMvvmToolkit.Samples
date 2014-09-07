using Android.App;
using MugenMvvmToolkit.Views.Activities;

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