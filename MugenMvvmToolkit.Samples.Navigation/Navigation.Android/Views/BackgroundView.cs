using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class BackgroundView : MvvmAppCompatActivity
    {
        #region Constructors

        public BackgroundView() : base(Resource.Layout.TextView)
        {
        }

        #endregion
    }
}