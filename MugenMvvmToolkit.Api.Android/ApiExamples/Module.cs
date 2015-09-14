using System;
using ApiExamples.TemplateSelectors;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace ApiExamples
{
    public class Module : ModuleBase
    {
        #region Constructors

        public Module()
            : base(true, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        /// <summary>
        ///     Loads the current module.
        /// </summary>
        protected override bool LoadInternal()
        {
            BindingServiceProvider
                .ResourceResolver
                .AddObject("listItemTemplateSelector", new ListItemTemplateSelector());
            BindingServiceProvider
                .ResourceResolver
                .AddObject("preferenceSelector", new PreferenceTemplateSelector());
            return true;
        }

        private object Method(object o, IDataContext dataContext)
        {
            return o;
        }

        /// <summary>
        ///     Unloads the current module.
        /// </summary>
        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}