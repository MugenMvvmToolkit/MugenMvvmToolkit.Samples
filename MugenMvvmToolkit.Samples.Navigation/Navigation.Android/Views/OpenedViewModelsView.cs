using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity]
    public class OpenedViewModelsView : MvvmAppCompatActivity
    {
        #region Constructors

        public OpenedViewModelsView() : base(Resource.Layout.OpenedViewModelsView)
        {
        }

        #endregion
    }
}