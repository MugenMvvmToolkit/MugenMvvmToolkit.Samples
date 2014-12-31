using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace ApiExamples.Views.Menus
{
    [Activity(Label = "ApiExamples"/*, Theme = "@style/ToolbarTheme"*/)]
    public class ToolbarActivityView : MvvmActivity
    {
        #region Constructors

        public ToolbarActivityView()
            : base(Resource.Layout.ToolbarView)
        {
        }

        #endregion
    }
}