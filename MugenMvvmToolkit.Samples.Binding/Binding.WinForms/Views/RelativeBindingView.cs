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
                set.Bind(trackBarTb)
                   .To<object>(() => (vm, ctx) => ctx.Element<TrackBar>("trackBar").Value)
                   .TwoWay();
                set.Bind(titleTb)
                   .To(() => (vm, ctx) => ctx.Relative<Form>().Text)
                   .TwoWay();
                set.Bind(selfLabel)
                   .ToSelf(() => (label, ctx) => label.Width);
                set.Bind(rootLabel)
                   .To(() => (vm, ctx) => ctx.Root<object>());
            }
        }
    }
}