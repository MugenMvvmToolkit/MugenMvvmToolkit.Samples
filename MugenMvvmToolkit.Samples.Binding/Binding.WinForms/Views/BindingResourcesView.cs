using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class BindingResourcesView : Form
    {
        public BindingResourcesView()
        {
            InitializeComponent();

            using (var set = new BindingSet<BindingResourcesViewModel>())
            {
                set.Bind(objLabel)
                    .To(() => model => BindingSyntaxEx.Resource<object>("obj"));
                set.Bind(methodLabel)
                    .To(() => model => BindingSyntaxEx.ResourceMethod<object>("Method"));
                set.BindFromExpression(typeLabel, "Text $CustomType.StaticMethod()");
                set.Bind(updateResBtn)
                    .To(() => vm => vm.UpdateResourceCommand);
            }
        }
    }
}