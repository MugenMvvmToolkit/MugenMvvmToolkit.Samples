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
                set.Bind(textBox, () => box => box.Text).To(() => model => model.Text).TwoWay();
                set.Bind(autoPropLabel, "TextExt").To(() => vm => vm.Text);
                set.Bind(customPropLabel, "FormattedText").To(() => vm => vm.Text);
            }
        }
    }
}