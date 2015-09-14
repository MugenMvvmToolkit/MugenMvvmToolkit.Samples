using System.Collections.Generic;
using Android.App;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Android.Views.Activities;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof(PreferenceViewModel), Constants.PreferenceHeaderView)]
    public class PreferenceHeaderView : MvvmPreferenceActivity
    {
        #region Methods

        public override void OnBuildHeaders(IList<Header> target)
        {
            base.OnBuildHeaders(target);
            LoadHeadersFromResource(Resource.Xml.prefheaders, target);
        }

        protected override bool IsValidFragment(string fragmentName)
        {
            return fragmentName.Equals("ApiExamples.Views.Fragments.PreferenceFragmentView");
        }

        #endregion
    }
}