using Android.App;
using Android.OS;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace SplitView.Android.Views
{
    [Activity(Label = "MainView")]
    public class MainView : MvvmAppCompatActivity
    {
        #region Constructors

        public MainView()
            : base(Resource.Layout.Main)
        {
        }

        #endregion

        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        #endregion
    }
}