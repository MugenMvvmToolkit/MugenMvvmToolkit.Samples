using System.Windows.Forms;
using Binding.Portable.ViewModels;
using Binding.WinForms.Templates;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace Binding.WinForms.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            using (var set = new BindingSet<MainViewModel>())
            {
                tableLayoutPanel1.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector,
                    ButtonItemTemplate.Instance);
                set.Bind(tableLayoutPanel1, AttachedMemberConstants.ItemsSource)
                   .To(() => vm => vm.Items);
                set.Bind(toolStripStatusLabel, () => t => t.Text)
                   .To(() => vm => vm.ResourceUsageInfo);
            }
        }
    }
}