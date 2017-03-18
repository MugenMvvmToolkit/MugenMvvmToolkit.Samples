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
                set.Bind(pictureBox, "ImageUrl").To(() => (vm, ctx) => vm.ImageUrl);
            }
        }
    }
}