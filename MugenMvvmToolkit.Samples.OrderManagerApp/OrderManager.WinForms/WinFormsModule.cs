using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Models;
using OrderManager.Portable.Interfaces;
using OrderManager.WinForms.Templates;
using OrderManager.WinForms.Views;
using OrderManager.Wpf.Infrastructure;

namespace OrderManager.WinForms
{
    public class WinFormsModule : ModuleBase
    {
        #region Fields

        /// <summary>
        ///     Defines the attached property for busy indicator.
        /// </summary>
        private static readonly IAttachedBindingMemberInfo<Control, BusyIndicator> BusyViewMember;

        #endregion

        #region Constructors

        static WinFormsModule()
        {
            BusyViewMember = AttachedBindingMember.CreateAutoProperty<Control, BusyIndicator>("#busyView",
                getDefaultValue: (control, info) => new BusyIndicator());
        }

        public WinFormsModule()
            : base(true, LoadMode.All, int.MinValue)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            if (Mode != LoadMode.Design)
                IocContainer.BindToConstant<IRepository>(new FileRepository());
            IBindingResourceResolver resourceResolver = BindingServiceProvider.ResourceResolver;
            IBindingMemberProvider memberProvider = BindingServiceProvider.MemberProvider;

            //Registering tab template resource.
            resourceResolver.AddObject("tabTemplate",
                new BindingResourceObject(new ViewModelTabDataTemplate()));

            //Registering content manager to set content value in code-behind.
            resourceResolver.AddObject("editorContentManager",
                new BindingResourceObject(new WrapperContentManager()));

            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<Control, bool>("IsBusy", IsBusyChanged));
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<Control, object>("BusyMessage",
                BusyMessageChanged));
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        private static void IsBusyChanged(Control control, AttachedMemberChangedEventArgs<bool> args)
        {
            BusyIndicator busyIndicator = BusyViewMember.GetValue(control, null);
            if (args.NewValue)
            {
                for (int index = 0; index < control.Controls.Count; index++)
                    control.Controls[index].Enabled = false;
                control.Controls.Add(busyIndicator);
                busyIndicator.Left = (control.ClientSize.Width - busyIndicator.Width)/2;
                busyIndicator.Top = (control.ClientSize.Height - busyIndicator.Height)/2;
                busyIndicator.BringToFront();
            }
            else
            {
                control.Controls.Remove(busyIndicator);
                for (int index = 0; index < control.Controls.Count; index++)
                    control.Controls[index].Enabled = true;
            }
        }

        private static void BusyMessageChanged(Control control, AttachedMemberChangedEventArgs<object> args)
        {
            BusyIndicator busyIndicator = BusyViewMember.GetValue(control, null);
            busyIndicator.BusyMessage = args.NewValue;
        }

        #endregion
    }
}