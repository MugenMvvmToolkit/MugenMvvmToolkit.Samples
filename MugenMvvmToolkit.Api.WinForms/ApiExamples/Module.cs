using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
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
            IBindingMemberInfo bindingMember = BindingServiceProvider.MemberProvider.GetBindingMember(
                typeof (TreeView), "AfterSelect", false, false);
            if (bindingMember != null)
                BindingServiceProvider.MemberProvider.Register(typeof (TreeView), "SelectedNodeChanged", bindingMember,
                    true);
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