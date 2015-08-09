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
    [ViewModel(typeof(TabViewModel), Constants.TabLayoutView)]
    public class TabLayoutActivityView : MvvmActivity
    {
        #region Constructors

        public TabLayoutActivityView()
            : base(Resource.Layout.TabLayoutView)
        {
        }

        #endregion
    }
}