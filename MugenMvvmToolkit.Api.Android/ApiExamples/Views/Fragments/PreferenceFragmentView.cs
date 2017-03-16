using System;
using Android.OS;
using Android.Runtime;
#if APPCOMPAT
using MvvmPreferenceFragment = MugenMvvmToolkit.Android.PreferenceCompat.Views.Fragments.MvvmPreferenceFragmentCompat;

#else
using MugenMvvmToolkit.Android.Views.Fragments;
#endif

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

#if APPCOMPAT
        public override void OnCreatePreferences(Bundle savedInstanceState, string rootKey)
        {
        }
#endif
        #endregion
    }
}