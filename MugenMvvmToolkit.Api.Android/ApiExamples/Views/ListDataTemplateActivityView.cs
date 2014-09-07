using Android.App;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;

#endif

namespace ApiExamples.Views
{
#if API8
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat")]    
#else
    [Activity(Label = "ApiExamples")]
#endif
    public class ListDataTemplateActivityView : MvvmActivity
    {
        #region Constructors

        public ListDataTemplateActivityView() : base(Resource.Layout.ListDataTemplateView)
        {
        }

        #endregion
    }
}