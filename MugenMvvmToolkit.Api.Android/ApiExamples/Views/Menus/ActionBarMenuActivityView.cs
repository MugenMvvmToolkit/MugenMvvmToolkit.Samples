using Android.App;
using ApiExamples.ViewModels.Menus;
using MugenMvvmToolkit.Attributes;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.AppCompat.Views.Activities.MvvmActionBarActivity;    
#else
using MugenMvvmToolkit.Views.Activities;
#endif

namespace ApiExamples.Views.Menus
{
    [Activity(Label = "ApiExamples")]
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