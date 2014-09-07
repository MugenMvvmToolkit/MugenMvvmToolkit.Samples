using Android.App;
using ApiExamples.ViewModels.Menus;
using MugenMvvmToolkit.Attributes;
#if API8
using MvvmActivity = MugenMvvmToolkit.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Menus
{
#if API8
    [Activity(Label = "ApiExamples", Theme = "@style/Theme.AppCompat")]    
#else
    [Activity(Label = "ApiExamples")]
#endif
    [ViewModel(typeof (MenuViewModel))]
    public class ActionBarMenuActivityView : MvvmActivity
    {
        #region Constructors

        public ActionBarMenuActivityView()
            : base(Resource.Layout.ActionBarMenuView)
        {
        }

        #endregion
    }
}