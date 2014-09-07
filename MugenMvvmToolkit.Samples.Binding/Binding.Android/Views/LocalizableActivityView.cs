using Android.App;
using MugenMvvmToolkit.Views.Activities;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class LocalizableActivityView : MvvmActivity
    {
        public LocalizableActivityView()
            : base(Resource.Layout.LocalizableView)
        {
        }
    }
}