using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace OrderManager.Android.Views
{
    [Activity(Label = "OrderManager.Android")]
    public class EditorWrapperActivityView : MvvmActivity
    {
        public EditorWrapperActivityView()
            : base(Resource.Layout.EditorWrapperView)
        {
        }
    }
}