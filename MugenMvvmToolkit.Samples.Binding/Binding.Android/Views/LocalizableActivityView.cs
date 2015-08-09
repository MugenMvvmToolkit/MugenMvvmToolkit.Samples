using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class LocalizableActivityView : MvvmAppCompatActivity
    {
        public LocalizableActivityView()
            : base(Resource.Layout.LocalizableView)
        {
        }
    }
}