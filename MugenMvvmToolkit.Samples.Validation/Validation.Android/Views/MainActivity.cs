using Android.App;
using MugenMvvmToolkit.Android.Views.Activities;

namespace Validation.Android.Views
{
    [Activity(Label = "Validation.Android", Icon = "@drawable/icon")]
    public class MainActivity : MvvmActivity
    {
        #region Constructors

        public MainActivity()
            : base(Resource.Layout.Main)
        {
        }

        #endregion
    }
}