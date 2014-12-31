using System.Drawing;
using System.Windows.Forms;
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
            resolver.AddObject("buttonTemplate", new BindingResourceObject(new ButtonItemTemplate()));
            resolver.AddObject("tabItemTemplate", new BindingResourceObject(new TabItemTemplate()));
            resolver.AddObject("treeNodeTemplate", new BindingResourceObject(new TreeNodeHierarchicalTemplate()));
            resolver.AddObject("tableLayoutCollectionManager",
                new BindingResourceObject(new TableLayoutCollectionViewManager()));
            resolver.AddObject("contentViewManager", new BindingResourceObject(new ContentViewManager()));
            resolver.AddObject("treeNodeCollectionViewManager", new BindingResourceObject(new TreeNodeCollectionViewManager()));
            resolver.AddType("Color", typeof(Color));

            var bindingMember = BindingServiceProvider.MemberProvider.GetBindingMember(typeof(TreeView), "AfterSelect", false, false);
            if (bindingMember != null)
                BindingServiceProvider.MemberProvider.Register(typeof(TreeView), "SelectedNodeChanged", bindingMember, true);
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