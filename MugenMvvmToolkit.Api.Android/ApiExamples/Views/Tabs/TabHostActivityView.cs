using Android.App;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Views.Activities;

namespace ApiExamples.Views.Tabs
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof (TabViewModel), Constants.TabHostView)]
    public class TabHostActivityView : MvvmTabActivity
    {
        #region Constructors

        public TabHostActivityView()
            : base(Resource.Layout.TabHostView)
        {
        }

        #endregion
    }
}