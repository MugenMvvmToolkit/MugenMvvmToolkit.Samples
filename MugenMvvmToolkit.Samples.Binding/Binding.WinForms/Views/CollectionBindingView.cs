using System.Windows.Forms;
using Binding.Portable.ViewModels;
using Binding.WinForms.CollectionManagers;
using Binding.WinForms.Templates;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace Binding.WinForms.Views
{
    public partial class CollectionBindingView : Form
    {
        public CollectionBindingView()
        {
            InitializeComponent();

            using (var set = new BindingSet<CollectionBindingViewModel>())
            {
                listView.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector, ListViewItemTemplate.Instance);
                listView.SetBindingMemberValue(AttachedMembers.Object.CollectionViewManager, ListViewCollectionManager.Instance);
                set.Bind(listView, AttachedMemberConstants.ItemsSource)
                    .To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
                set.Bind(listView, AttachedMemberConstants.SelectedItem)
                    .To(() => (vm, ctx) => vm.GridViewModel.SelectedItem)
                    .TwoWay();

                set.Bind(filterTb)
                    .To(() => (vm, ctx) => vm.FilterText)
                    .TwoWay();

                set.Bind(addButton).To(() => (vm, ctx) => vm.AddCommand);
                set.Bind(removeButton).To(() => (vm, ctx) => vm.RemoveCommand);
            }
        }
    }
}