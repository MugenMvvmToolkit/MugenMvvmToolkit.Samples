using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.iOS.Binding;

namespace OrderManager.Touch
{
    public static class AttachedMembersEx
    {
        public class UIView : AttachedMembers.UIView
        {
            #region Fields

            public static readonly BindingMemberDescriptor<UIKit.UIView, bool> IsBusy;
            public static readonly BindingMemberDescriptor<UIKit.UIView, object> BusyMessage;

            #endregion

            #region Constructors

            static UIView()
            {
                IsBusy = new BindingMemberDescriptor<UIKit.UIView, bool>("IsBusy");
                BusyMessage = new BindingMemberDescriptor<UIKit.UIView, object>("BusyMessage");
            }

            #endregion
        }
    }
}