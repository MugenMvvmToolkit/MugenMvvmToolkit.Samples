using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace OrderManager.Android.Views
{
    [Activity(Label = "OrderManager.Android")]
    public class EditorWrapperActivityView : MvvmAppCompatActivity
    {
        public EditorWrapperActivityView()
            : base(Resource.Layout.EditorWrapperView)
        {
        }
    }
}