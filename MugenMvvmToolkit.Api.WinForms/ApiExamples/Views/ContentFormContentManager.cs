using System.Windows.Forms;
using ApiExamples.ContentManagers;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Views
{
    [ViewModel(typeof (ContentViewModel), Constants.ContentFormContentManager)]
    public partial class ContentFormContentManager : Form
    {
        public ContentFormContentManager()
        {
            InitializeComponent();
            using (var set = new BindingSet<ContentViewModel>())
            {
                set.Bind(this, AttachedMemberConstants.Content).To(() => (vm, ctx) => vm.ViewModel);
                this.SetBindingMemberValue(AttachedMembers.Control.ContentViewManager, ContentViewManager.Instance);
            }
        }
    }
}