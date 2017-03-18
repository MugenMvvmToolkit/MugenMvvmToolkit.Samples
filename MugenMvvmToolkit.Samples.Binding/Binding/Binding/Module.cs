using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using Xamarin.Forms;

namespace Binding
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Methods

        /// <summary>
        ///     Called once for each element in the time of accession to obtain default values.
        /// </summary>
        private static string TextExtGetDefaultValue(Label textBlock, IBindingMemberInfo bindingMemberInfo)
        {
            if (!ServiceProvider.IsDesignMode)
            {
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtGetDefaultValue on " + textBlock.ClassId, ToastDuration.Short);
            }
            return "Default value";
        }

        /// <summary>
        ///     Called once for each element in the time of accession.
        /// </summary>
        private static void TextExtMemberAttached(Label textBlock, MemberAttachedEventArgs args)
        {
            if (!ServiceProvider.IsDesignMode)
            {
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtMemberAttached on " + textBlock.ClassId, ToastDuration.Short);
            }
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static void TextExtMemberChanged(Label textBlock, AttachedMemberChangedEventArgs<string> args)
        {
            if (!ServiceProvider.IsDesignMode)
            {
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync(string.Format("Invoking TextExtMemberChanged on {2} old value {0} new value {1}", args.OldValue,
                        args.NewValue, textBlock.ClassId), ToastDuration.Short);
            }
            textBlock.Text = string.Format("Old value \"{0}\" new value \"{1}\"", args.OldValue, args.NewValue);
        }

        /// <summary>
        ///     Used to observe member.
        /// </summary>
        private static IDisposable ObserveFormattedTextValue(IBindingMemberInfo bindingMemberInfo, Label textBlock, IEventListener arg3)
        {
            return null;
            //                        return BindingServiceProvider.WeakEventManager.TrySubscribe(textBlock, "EventName", arg3);
        }

        /// <summary>
        ///     Called every time when value updated.
        /// </summary>
        private static void SetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, Label textBlock, string value)
        {
            textBlock.Text = "Formatted " + value;
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static string GetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, Label textBlock)
        {
            return textBlock.Text;
        }

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<Label, string>("TextExt",
                TextExtMemberChanged, TextExtMemberAttached, TextExtGetDefaultValue));

            memberProvider.Register(AttachedBindingMember.CreateMember<Label, string>("FormattedText",
                GetFormattedTextValue, SetFormattedTextValue, ObserveFormattedTextValue));
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}