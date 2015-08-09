using Android.App;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace Navigation.Android.Views
{
    [Activity(Label = "Navigation.Android")]
    public class BackStackView : MvvmAppCompatActivity 
    {
        public BackStackView()
            : base(Resource.Layout.BackStackView)
        {
        }
    }
}