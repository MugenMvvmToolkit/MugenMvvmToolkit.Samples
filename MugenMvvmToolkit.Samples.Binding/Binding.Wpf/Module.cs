using System;
#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Binding.Portable.Interfaces;
using Binding.UniversalApp.UniversalApp.Infrastructure;
using MugenMvvmToolkit.Models.IoC;
#else
using System.Windows.Controls;
#endif
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;

namespace Binding.Wpf
{
    public class Module : ModuleBase
    {
        #region Constructors

        public Module()
            : base(true, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
#if NETFX_CORE
            IocContainer.BindToMethod<ILocalizationManager>((container, list) =>
                        {
                            var manager = new LocalizationManagerExt();
                            manager.Initilaize();
                            return manager;
                        }, DependencyLifecycle.SingleInstance);
#endif

            //Registering attached property
            IBindingMemberProvider memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<TextBlock, string>("TextExt",
                TextExtMemberChanged, TextExtMemberAttached, TextExtGetDefaultValue));

            memberProvider.Register(AttachedBindingMember.CreateMember<TextBlock, string>("FormattedText",
                GetFormattedTextValue, SetFormattedTextValue, ObserveFormattedTextValue));
            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Called once for each element in the time of accession to obtain default values.
        /// </summary>
        private static string TextExtGetDefaultValue(TextBlock textBlock, IBindingMemberInfo bindingMemberInfo)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtGetDefaultValue on " + textBlock.Name, ToastDuration.Short);
            return "Default value";
        }

        /// <summary>
        ///     Called once for each element in the time of accession.
        /// </summary>
        private static void TextExtMemberAttached(TextBlock textBlock, MemberAttachedEventArgs args)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtMemberAttached on " + textBlock.Name, ToastDuration.Short);
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static void TextExtMemberChanged(TextBlock textBlock, AttachedMemberChangedEventArgs<string> args)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync(string.Format("Invoking TextExtMemberChanged on {2} old value {0} new value {1}", args.OldValue,
                            args.NewValue, textBlock.Name), ToastDuration.Short);
            textBlock.Text = string.Format("Old value \"{0}\" new value \"{1}\"", args.OldValue, args.NewValue);
        }

        /// <summary>
        ///     Used to observe member.
        /// </summary>
        private static IDisposable ObserveFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextBlock textBlock, IEventListener arg3)
        {
            return null;
            //            return BindingServiceProvider.WeakEventManager.TrySubscribe(textBlock, "EventName", arg3);
        }

        /// <summary>
        ///     Called every time when value updated.
        /// </summary>
        private static void SetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextBlock textBlock, string value)
        {
            textBlock.Text = "Formatted " + value;
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static string GetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextBlock textBlock)
        {
            return textBlock.Text;
        }

        #endregion
    }
}