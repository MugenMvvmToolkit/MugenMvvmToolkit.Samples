using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.WinForms.Binding;

namespace OrderManager.WinForms
{
    public static class AttachedMembersEx
    {
        public class Control : AttachedMembers.Control
        {
            #region Fields

            public static readonly BindingMemberDescriptor<System.Windows.Forms.Control, bool> IsBusy;
            public static readonly BindingMemberDescriptor<System.Windows.Forms.Control, object> BusyMessage;

            #endregion

            #region Constructors

            static Control()
            {
                IsBusy = new BindingMemberDescriptor<System.Windows.Forms.Control, bool>("IsBusy");
                BusyMessage = new BindingMemberDescriptor<System.Windows.Forms.Control, object>("BusyMessage");
            }

            protected Control()
            {
            }

            #endregion
        }
    }
}