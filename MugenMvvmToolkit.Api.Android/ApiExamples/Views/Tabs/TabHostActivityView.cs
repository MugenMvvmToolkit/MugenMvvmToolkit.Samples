using Android.App;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Attributes;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views.Tabs
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof (TabViewModel), Constants.TabHostView)]
    public class TabHostActivityView : MvvmActivity
    {
        #region Constructors

        public TabHostActivityView()
            : base(Resource.Layout.TabHostView)
        {
        }

        #endregion
    }
}