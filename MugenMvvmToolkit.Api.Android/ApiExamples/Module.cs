using ApiExamples.TemplateSelectors;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;

namespace ApiExamples
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            BindingServiceProvider
                .ResourceResolver
                .AddObject("listItemTemplateSelector", new ListItemTemplateSelector());
            BindingServiceProvider
                .ResourceResolver
                .AddObject("preferenceSelector", new PreferenceTemplateSelector());
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}