using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace ApiExamples.Views
{
    public partial class ContentForm : Form
    {
        public ContentForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<ContentViewModel>())
            {
                set.Bind(this, AttachedMemberConstants.Content).To(() => (vm, ctx) => vm.ViewModel);
            }
        }
    }
}