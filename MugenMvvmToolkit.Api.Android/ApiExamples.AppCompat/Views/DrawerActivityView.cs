using Android.App;
using MugenMvvmToolkit.AppCompat.Views.Activities;

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    public class DrawerActivityView : MvvmActionBarActivity
    {
        #region Constructors

        public DrawerActivityView()
            : base(Resource.Layout.DrawerView)
        {
        }

        #endregion
    }
}