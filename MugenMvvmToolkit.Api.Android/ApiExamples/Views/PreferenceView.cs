using Android.App;
using Android.OS;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Android.Views.Activities;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof(PreferenceViewModel))]
    public class PreferenceView : MvvmPreferenceActivity
    {
        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.pref);
        }

        #endregion
    }
}