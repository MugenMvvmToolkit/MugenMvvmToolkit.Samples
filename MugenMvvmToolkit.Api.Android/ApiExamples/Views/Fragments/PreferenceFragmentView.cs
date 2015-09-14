using Android.OS;
using Android.Runtime;
using MugenMvvmToolkit.Android.Views.Fragments;

namespace ApiExamples.Views.Fragments
{
    [Register("ApiExamples.Views.Fragments.PreferenceFragmentView")]
    public class PreferenceFragmentView : MvvmPreferenceFragment
    {
        #region Methods

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.pref);
        }

        #endregion
    }
}