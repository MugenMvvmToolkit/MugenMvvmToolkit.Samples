using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class PageView : MvvmAppCompatActivity
    {
        #region Constructors

        public PageView() : base(Resource.Layout.TextView)
        {
        }

        #endregion
    }
}