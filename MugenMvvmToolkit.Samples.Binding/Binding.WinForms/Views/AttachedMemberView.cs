using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Binding.WinForms.Views
{
    public partial class AttachedMemberView : Form
    {
        public AttachedMemberView()
        {
            InitializeComponent();

            using (var set = new BindingSet<AttachedMemberViewModel>())
            {
                set.Bind(textBox).To(() => (vm, ctx) => vm.Text).TwoWay();
                set.Bind(autoPropLabel, "TextExt").To(() => (vm, ctx) => vm.Text);
                set.Bind(customPropLabel, "FormattedText").To(() => (vm, ctx) => vm.Text);
            }
        }
    }
}