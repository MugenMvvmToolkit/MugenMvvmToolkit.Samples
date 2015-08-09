using Android.App;
using Android.Views;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;
using OrderManager.Android.Infrastructure;
using OrderManager.Portable.Interfaces;

namespace OrderManager.Android
{
    public class AndroidModule : ModuleBase
    {
        #region Fields

        private static readonly IAttachedBindingMemberInfo<View, ProgressDialog> ProgressDialogAttachedProperty;

        #endregion

        #region Constructors

        public AndroidModule()
            : base(false, LoadMode.Runtime)
        {
        }

        static AndroidModule()
        {
            ProgressDialogAttachedProperty = AttachedBindingMember.CreateAutoProperty<View, ProgressDialog>("pd");
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            BindingServiceProvider.MemberProvider.Register(AttachedBindingMember.CreateAutoProperty<View, bool>("IsBusy", IsBusyChanged));
            BindingServiceProvider.MemberProvider.Register(AttachedBindingMember.CreateAutoProperty<View, string>("BusyMessage", BusyMessageChanged));
            IocContainer.BindToConstant<IRepository>(new FileRepository());
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        private static void BusyMessageChanged(View view, AttachedMemberChangedEventArgs<string> args)
        {
            var dialog = ProgressDialogAttachedProperty.GetValue(view, null);
            if (dialog == null)
            {
                dialog = new ProgressDialog(view.Context);
                ProgressDialogAttachedProperty.SetValue(view, dialog);
            }
            dialog.SetMessage(args.NewValue);
        }

        private static void IsBusyChanged(View view, AttachedMemberChangedEventArgs<bool> args)
        {
            var dialog = ProgressDialogAttachedProperty.GetValue(view, null);
            if (dialog == null)
            {
                dialog = new ProgressDialog(view.Context);
                dialog.SetCancelable(false);
                ProgressDialogAttachedProperty.SetValue(view, dialog);
            }
            if (args.NewValue)
                dialog.Show();
            else
                dialog.Dismiss();
        }

        #endregion
    }
}