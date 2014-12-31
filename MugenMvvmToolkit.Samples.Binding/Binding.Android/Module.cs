using System;
using Android.Widget;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace Binding.Android
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

        protected override bool LoadInternal()
        {
            //Registering attached property
            IBindingMemberProvider memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<TextView, string>("TextExt",
                TextExtMemberChanged, TextExtMemberAttached, TextExtGetDefaultValue));

            memberProvider.Register(AttachedBindingMember.CreateMember<TextView, string>("FormattedText",
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
        private static string TextExtGetDefaultValue(TextView textBlock, IBindingMemberInfo bindingMemberInfo)
        {
            ServiceProvider
                .IocContainer
                .Get<IToastPresenter>()
                .ShowAsync("Invoking TextExtGetDefaultValue on " + textBlock.Id, ToastDuration.Short);
            return "Default value";
        }

        /// <summary>
        ///     Called once for each element in the time of accession.
        /// </summary>
        private static void TextExtMemberAttached(TextView textBlock, MemberAttachedEventArgs args)
        {
            ServiceProvider
                .IocContainer
                .Get<IToastPresenter>()
                .ShowAsync("Invoking TextExtMemberAttached on " + textBlock.Id, ToastDuration.Short);
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static void TextExtMemberChanged(TextView textBlock, AttachedMemberChangedEventArgs<string> args)
        {
            ServiceProvider
                .IocContainer
                .Get<IToastPresenter>()
                .ShowAsync(string.Format("Invoking TextExtMemberChanged on {2} old value {0} new value {1}", args.OldValue,
                        args.NewValue, textBlock.Id), ToastDuration.Short);
            textBlock.Text = string.Format("Old value \"{0}\" new value \"{1}\"", args.OldValue, args.NewValue);
        }

        /// <summary>
        ///     Used to observe member.
        /// </summary>
        private static IDisposable ObserveFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextView textBlock,
            IEventListener arg3)
        {
            return null;
            //            return BindingServiceProvider.WeakEventManager.TrySubscribe(textBlock, "EventName", arg3);
        }

        /// <summary>
        ///     Called every time when value updated.
        /// </summary>
        private static void SetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextView textBlock, string value)
        {
            textBlock.Text = "Formatted " + value;
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static string GetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, TextView textBlock)
        {
            return textBlock.Text;
        }

        #endregion
    }
}