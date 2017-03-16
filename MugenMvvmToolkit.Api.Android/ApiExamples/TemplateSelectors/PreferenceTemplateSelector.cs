using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Interfaces;
#if APPCOMPAT
using Android.Support.V7.Preferences;
#else
using Android.Preferences;

#endif

namespace ApiExamples.TemplateSelectors
{
    public class PreferenceTemplateSelector : IDataTemplateSelector
    {
        #region Implementation of interfaces

        public object SelectTemplate(object itemObj, object container)
        {
            var item = (PreferenceModel) itemObj;
            if (item == null)
                return null;
            var preference = (Preference) container;
            Preference result;
            using (var set = new BindingSet<PreferenceModel>())
            {
                if (item.IsCheckbox)
                {
                    var checkBoxPref = new CheckBoxPreference(preference.Context) {Key = item.Key};
                    result = checkBoxPref;
                    set.Bind(checkBoxPref, () => p => p.Checked)
                        .To(() => (m, ctx) => m.Value)
                        .TwoWay();
                }
                else
                {
                    var editTextPref = new EditTextPreference(preference.Context) {Key = item.Key};
                    result = editTextPref;
                    set.Bind(editTextPref, () => p => p.Text)
                        .To(() => (m, ctx) => m.Value)
                        .TwoWay();
                    set.Bind(editTextPref, () => p => p.Summary)
                        .ToSelf(() => (m, ctx) => m.Text);
                }
                set.Bind(result, () => p => p.Title).To(() => (m, ctx) => m.Title);
            }
            return result;
        }

        #endregion
    }
}