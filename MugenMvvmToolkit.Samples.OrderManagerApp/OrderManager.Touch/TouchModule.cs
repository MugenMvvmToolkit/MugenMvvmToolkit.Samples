using System.Drawing;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.Touch.Infrastructure;
using OrderManager.Touch.Views;

namespace OrderManager.Touch
{
    public class TouchModule : ModuleBase
    {
        #region Fields

        /// <summary>
        ///     Defines the attached property for busy indicator.
        /// </summary>
        private static readonly IAttachedBindingMemberInfo<UIView, LoadingOverlay> BusyViewMember;

        #endregion

        #region Constructors

        static TouchModule()
        {
            BusyViewMember = AttachedBindingMember.CreateAutoProperty<UIView, LoadingOverlay>("#busyView",
                getDefaultValue: CreateLoadingOverlay);
        }

        public TouchModule()
            : base(false, LoadMode.Runtime)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            IocContainer.BindToConstant<IRepository>(new FileRepository());

            IBindingMemberProvider memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<UIView, bool>("IsBusy", IsBusyChanged));
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<UIView, object>("BusyMessage",
                BusyMessageChanged));

            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        private static LoadingOverlay CreateLoadingOverlay(UIView uiView, IBindingMemberInfo bindingMemberInfo)
        {
            // Determine the correct size to start the overlay (depending on device orientation)
            RectangleF bounds = UIScreen.MainScreen.Bounds; // portrait bounds
            if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft ||
                UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight)
            {
                bounds.Size = new SizeF(bounds.Size.Height, bounds.Size.Width);
            }
            return new LoadingOverlay(bounds);
        }

        private static void IsBusyChanged(UIView uiView, AttachedMemberChangedEventArgs<bool> args)
        {
            //Ignoring view and set overlay over main window
            uiView = UIApplication.SharedApplication.Windows[0];
            LoadingOverlay busyIndicator = BusyViewMember.GetValue(uiView, null);
            if (args.NewValue)
                busyIndicator.Show(uiView);
            else
                busyIndicator.Hide();
        }

        private static void BusyMessageChanged(UIView uiView, AttachedMemberChangedEventArgs<object> args)
        {
            //Ignoring view and set overlay over main window
            uiView = UIApplication.SharedApplication.Windows[0];
            LoadingOverlay busyIndicator = BusyViewMember.GetValue(uiView, null);
            busyIndicator.BusyMessage = args.NewValue == null ? null : args.NewValue.ToString();
        }

        #endregion
    }
}