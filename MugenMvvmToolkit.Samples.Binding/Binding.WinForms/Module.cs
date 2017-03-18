using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;

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

        private static void OnImageUrlChanged(PictureBox pictureBox, AttachedMemberChangedEventArgs<string> args)
        {
            if (string.IsNullOrEmpty(args.NewValue))
                return;
            //for example you can use any cache library to load image
            pictureBox.ImageLocation = args.NewValue;
        }

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateMember<ListView, object>(AttachedMemberConstants.SelectedItem, GetListViewSelectedItem, SetListViewSelectedItem,
                "ItemSelectionChanged"));
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<PictureBox, string>("ImageUrl", OnImageUrlChanged));
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}