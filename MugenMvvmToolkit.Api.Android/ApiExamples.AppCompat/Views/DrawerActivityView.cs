using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    public class DrawerActivityView : MvvmAppCompatActivity
    {
        #region Constructors

        public DrawerActivityView()
            : base(Resource.Layout.DrawerView)
        {
        }

        #endregion
    }
}