using ApiExamples.ContentManagers;
using ApiExamples.Templates;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

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
            resolver.AddObject("buttonTemplate", new BindingResourceObject(new ButtonItemTemplateSelector()));
            resolver.AddObject("cellDataTemplate", new BindingResourceObject(new TableCellTemplateSelector()));
            resolver.AddObject("tabDataTemplate", new BindingResourceObject(new TabTemplateSelector()));
            resolver.AddObject("collectionViewCellTemplate", new BindingResourceObject(new CollectionViewCellTemplateSelector()));
            resolver.AddObject("collectionViewManager", new BindingResourceObject(new CollectionViewManager()));
            resolver.AddObject("labelItemTemplate", new BindingResourceObject(new LabelItemTemplateSelector()));
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