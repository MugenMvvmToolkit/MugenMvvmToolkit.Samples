using Android.App;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Attributes;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Tabs
{
#if API8
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat")]    
#else
    [Activity(Label = "ApiExamples")]
#endif
    [ViewModel(typeof (TabViewModel))]
    public class ActionBarTabActivityView : MvvmActivity
    {
        #region Constructors

        public ActionBarTabActivityView()
            : base(Resource.Layout.ActionBarDynamicTabView)
        {
        }

        #endregion
    }
}