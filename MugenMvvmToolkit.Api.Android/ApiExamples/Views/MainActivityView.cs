using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    public class MainActivityView : MvvmActivity
    {
        #region Constructors

        public MainActivityView()
            : base(Resource.Layout.MainView)
        {
        }

        #endregion
    }
}