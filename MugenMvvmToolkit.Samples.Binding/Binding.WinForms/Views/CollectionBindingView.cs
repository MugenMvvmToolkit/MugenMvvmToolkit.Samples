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
                    .To(() => vm => vm.GridViewModel.ItemsSource);
                set.Bind(listView, AttachedMemberConstants.SelectedItem)
                    .To(() => vm => vm.GridViewModel.SelectedItem)
                    .TwoWay();

                set.Bind(filterTb, () => tb => tb.Text)
                    .To(() => vm => vm.FilterText)
                    .TwoWay();

                set.Bind(addButton, "Click").To(() => vm => vm.AddCommand);
                set.Bind(removeButton, "Click").To(() => vm => vm.RemoveCommand);
            }
        }
    }
}