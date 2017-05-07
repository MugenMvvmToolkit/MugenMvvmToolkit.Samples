using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class MainView : MvvmAppCompatActivity
    {
        #region Constructors

        public MainView()
            : base(Resource.Layout.Main)
        {
        }

        #endregion
    }
}