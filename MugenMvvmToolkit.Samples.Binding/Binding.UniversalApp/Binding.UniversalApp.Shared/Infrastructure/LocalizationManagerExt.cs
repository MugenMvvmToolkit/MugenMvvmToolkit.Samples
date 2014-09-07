using System.Collections.Generic;
using Windows.ApplicationModel.Resources.Core;
using Windows.Globalization;
using Binding.Portable.Infrastructure;

namespace Binding.UniversalApp.UniversalApp.Infrastructure
{
    public class LocalizationManagerExt : LocalizationManager
    {
        #region Overrides of LocalizationManager

        public override void ChangeCulture(string culture)
        {
            ApplicationLanguages.PrimaryLanguageOverride = culture.Substring(0, culture.IndexOf('-'));
            base.ChangeCulture(culture);
        }

        public override object GetMember(string member, IList<object> args)
        {
            //NOTE ApplicationLanguages.PrimaryLanguageOverride doens't work as expected
            return member + " " + ApplicationLanguages.PrimaryLanguageOverride;
        }

        public override void Initilaize()
        {
            ResourceContext context = ResourceContext.GetForCurrentView();
            context.Reset();
            base.Initilaize();
        }

        #endregion
    }
}