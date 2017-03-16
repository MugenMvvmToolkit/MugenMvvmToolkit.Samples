using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;

namespace ApiExamples
{
    public class Module : IModule
    {
        #region Overrides of ModuleBase

        public bool Load(IModuleContext context)
        {
            var bindingMember = BindingServiceProvider.MemberProvider.GetBindingMember(
                typeof(TreeView), "AfterSelect", false, false);
            if (bindingMember != null)
            {
                BindingServiceProvider.MemberProvider.Register(typeof(TreeView), "SelectedNodeChanged", bindingMember,
                    true);
            }
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion
    }
}