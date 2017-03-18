using System;
using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;

namespace Binding.WinForms
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Methods

        private static void SetListViewSelectedItem(IBindingMemberInfo bindingMemberInfo, ListView listView, object value)
        {
            //Clear selection
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Focused = false;
                item.Selected = false;
            }
            if (value == null)
                return;
            foreach (ListViewItem item in listView.Items)
            {
                if (Equals(item.DataContext(), value))
                {
                    item.Focused = true;
                    item.Selected = true;
                    break;
                }
            }
        }

        private static object GetListViewSelectedItem(IBindingMemberInfo bindingMemberInfo, ListView listView)
        {
            var items = listView.SelectedItems;
            if (items.Count == 0)
                return null;
            return items[0].DataContext();
        }

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
                    .ShowAsync("Invoking TextExtGetDefaultValue on " + textBlock.Name, ToastDuration.Short);
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
                    .ShowAsync("Invoking TextExtMemberAttached on " + textBlock.Name, ToastDuration.Short);
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
                        args.NewValue, textBlock.Name), ToastDuration.Short);
            }
            textBlock.Text = string.Format("Old value \"{0}\" new value \"{1}\"", args.OldValue, args.NewValue);
        }

        /// <summary>
        ///     Used to observe member.
        /// </summary>
        private static IDisposable ObserveFormattedTextValue(IBindingMemberInfo bindingMemberInfo, Label label, IEventListener arg3)
        {
            return null;
            //            return BindingServiceProvider.WeakEventManager.TrySubscribe(label, "EventName", arg3);            
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
            memberProvider.Register(
                AttachedBindingMember.CreateMember<ListView, object>(AttachedMemberConstants.SelectedItem,
                    GetListViewSelectedItem, SetListViewSelectedItem, "ItemSelectionChanged"));

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