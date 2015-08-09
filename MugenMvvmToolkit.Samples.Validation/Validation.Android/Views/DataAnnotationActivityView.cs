using Android.App;
using MugenMvvmToolkit.Android.Views.Activities;

namespace Validation.Android.Views
{
    [Activity(Label = "Validation.Android")]
    public class DataAnnotationActivityView : MvvmActivity
    {
        #region Constructors

        public DataAnnotationActivityView()
            : base(Resource.Layout.DataAnnotationView)
        {
        }

        #endregion
    }
}