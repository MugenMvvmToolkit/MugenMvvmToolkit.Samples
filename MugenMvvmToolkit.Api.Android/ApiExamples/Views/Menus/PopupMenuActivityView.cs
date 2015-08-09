using Android.App;
using ApiExamples.ViewModels.Menus;
using MugenMvvmToolkit.Attributes;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views.Menus
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof (MenuViewModel), Constants.PopupMenuView)]
    public class PopupMenuActivityView : MvvmActivity
    {
        #region Constructors

        public PopupMenuActivityView()
            : base(Resource.Layout.PopupMenuView)
        {
        }

        #endregion
    }
}