using ApiExamples.ContentManagers;
using ApiExamples.Templates;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Core;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Models;

namespace ApiExamples
{
    public class Module : ModuleBase
    {
        #region Constructors

        public Module()
            : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        /// <summary>
        ///     Loads the current module.
        /// </summary>
        protected override bool LoadInternal()
        {
            IBindingResourceResolver resolver = BindingServiceProvider.ResourceResolver;
            resolver.AddObject("buttonTemplate", new BindingResourceObject(new ButtonItemTemplate()));
            resolver.AddObject("tabItemTemplate", new BindingResourceObject(new TabItemTemplate()));
            resolver.AddObject("tableLayoutCollectionManager", new BindingResourceObject(new TableLayoutCollectionViewManager()));
            resolver.AddObject("contentViewManager", new BindingResourceObject(new ContentViewManager()));
            return true;
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