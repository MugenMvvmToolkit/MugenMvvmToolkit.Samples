using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Validation.Android.Views
{
    [Activity(Label = "Validation.Android")]
    public class UserWorkspaceActivityView : MvvmActivity
    {
        #region Constructors

        public UserWorkspaceActivityView()
            : base(Resource.Layout.UserWorkspaceView)
        {
        }

        #endregion
    }
}