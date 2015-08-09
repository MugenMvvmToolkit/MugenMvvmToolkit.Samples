using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class RelativeBindingView : Form
    {
        public RelativeBindingView()
        {
            InitializeComponent();

            using (var set = new BindingSet<RelativeBindingViewModel>())
            {
                set.Bind(trackBarTb, () => t => t.Text)
                   .To<object>(() => vm => BindingSyntaxEx.Element<TrackBar>("trackBar").Value)
                   .TwoWay();
                set.Bind(titleTb, () => t => t.Text)
                   .To(() => vm => BindingSyntaxEx.Relative<Form>().Text)
                   .TwoWay();
                set.Bind(selfLabel, () => label => label.Text)
                   .ToSelf(() => label => label.Width);
                set.Bind(rootLabel, () => label => label.Text)
                   .To(() => vm => BindingSyntaxEx.Root<object>());
            }
        }
    }
}