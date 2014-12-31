using Android.App;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;

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