using Android.App;
using Android.OS;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views.Tabs
{
    [Activity(Label = "ViewPagerActivityView")]
    [ViewModel(typeof(TabViewModel), Constants.ViewPagerView)]
    public class ViewPagerActivityView : MvvmAppCompatActivity
    {
        #region Constructors

        public ViewPagerActivityView()
            : base(Resource.Layout.ViewPagerView)
        {
        }

        #endregion

        #region Overrides of MvvmActionBarActivity

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        #endregion
    }
}