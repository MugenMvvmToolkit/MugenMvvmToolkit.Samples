using System.Windows.Forms;
using ApiExamples.ContentManagers;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Views
{
    [ViewModel(typeof(TabViewModel), Constants.CollectionViewManager)]
    public partial class CollectionViewManagerForm : Form
    {
        public CollectionViewManagerForm()
        {
            InitializeComponent();

            using (var set = new BindingSet<TabViewModel>())
            {
                set.Bind(addToolStripButton).To(() => (model, ctx) => model.AddCommand);
                set.Bind(removeToolStripButton).To(() => (model, ctx) => model.RemoveCommand);
                set.Bind(tableLayoutPanel, AttachedMemberConstants.ItemsSource).To(() => (model, ctx) => model.ItemsSource);
                tableLayoutPanel.SetBindingMemberValue(AttachedMembers.Object.CollectionViewManager, TableLayoutCollectionViewManager.Instance);
            }
        }
    }
}