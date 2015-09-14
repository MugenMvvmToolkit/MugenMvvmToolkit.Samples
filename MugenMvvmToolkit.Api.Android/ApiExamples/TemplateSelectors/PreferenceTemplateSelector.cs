using Android.Preferences;
using ApiExamples.Models;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.TemplateSelectors
{
    public class PreferenceTemplateSelector : DataTemplateSelectorBase<PreferenceModel, Preference>
    {
        #region Methods

        protected override void Initialize(Preference template, BindingSet<Preference, PreferenceModel> bindingSet)
        {
            bindingSet.Bind(() => p => p.Title).To(() => m => m.Title);
            var preference = template as EditTextPreference;
            if (preference == null)
            {
                bindingSet.Bind((CheckBoxPreference)template, () => p => p.Checked)
                   .To(() => m => m.Value)
                   .TwoWay();
            }
            else
            {
                bindingSet.Bind(preference, () => p => p.Text)
                    .To(() => m => m.Value)
                    .TwoWay();
                bindingSet.Bind(preference, () => p => p.Summary)
                    .ToSelf(() => p => p.Text);
            }
        }

        protected override Preference SelectTemplate(PreferenceModel item, object container)
        {
            var preference = (Preference)container;
            if (item.IsCheckbox)
                return new CheckBoxPreference(preference.Context) { Key = item.Key };
            return new EditTextPreference(preference.Context) { Key = item.Key };
        }

        #endregion
    }
}