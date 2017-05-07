using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class ResultView : MvvmAppCompatActivity
    {
        #region Constructors

        public ResultView() : base(Resource.Layout.ResultView)
        {
        }

        #endregion
    }
}