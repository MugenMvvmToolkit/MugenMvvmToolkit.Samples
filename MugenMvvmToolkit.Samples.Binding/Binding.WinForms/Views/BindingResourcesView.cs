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
                set.Bind(objLabel, () => label => label.Text)
                    .To(() => model => BindingSyntaxEx.Resource<object>("obj"));
                set.Bind(methodLabel, () => label => label.Text)
                    .To(() => model => BindingSyntaxEx.ResourceMethod<object>("Method"));
                set.BindFromExpression(typeLabel, "Text $CustomType.StaticMethod()");
            }
        }
    }
}