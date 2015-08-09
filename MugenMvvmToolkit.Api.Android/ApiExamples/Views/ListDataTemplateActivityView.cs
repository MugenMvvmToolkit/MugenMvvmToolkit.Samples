using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    public class ListDataTemplateActivityView : MvvmActivity
    {
        #region Constructors

        public ListDataTemplateActivityView() : base(Resource.Layout.ListDataTemplateView)
        {
        }

        #endregion
    }
}