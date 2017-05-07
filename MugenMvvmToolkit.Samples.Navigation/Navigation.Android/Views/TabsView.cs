using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity]
    public class TabsView : MvvmAppCompatActivity
    {
        #region Constructors

        public TabsView() : base(Resource.Layout.TabsView)
        {
        }

        #endregion
    }
}