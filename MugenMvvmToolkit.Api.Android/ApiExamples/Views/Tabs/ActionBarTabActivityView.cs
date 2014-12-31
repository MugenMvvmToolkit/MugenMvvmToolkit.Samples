using Android.App;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Attributes;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Tabs
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof(TabViewModel))]
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