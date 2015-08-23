using System.Linq;
using System.Windows.Forms;
using Binding.Portable;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Binding.WinForms.Views
{
    public partial class BindingExpressionView : Form
    {
        public BindingExpressionView()
        {
            InitializeComponent();

            using (var set = new BindingSet<BindingExpressionViewModel>())
            {
                set.Bind(textTb).To(() => model => model.Text).TwoWay();
                set.Bind(linqCountLabel)
                   .To(() => model => model.Text.OfType<char>().Count(x => x == 'a'));
                set.Bind(extMethodLabel)
                   .To(() => model => model.Text.ExtensionMethod(model.Text.Count()));
                set.Bind(linqSecondCharLabel)
                   .To(() => model => model.Text.OfType<char>().Skip(1).FirstOrDefault());
                set.Bind(conditionLabel)
                   .To(() => model => string.IsNullOrEmpty(model.Text) ? "String is empty" : "String is not empty");
                set.Bind(arithmeticLabel)
                   .To(() => model => model.Text.Count() + 100 + model.Text.GetHashCode());
                set.BindFromExpression(nullConditionalLabel, "Text NullableText?.Trim()?.Length ?? -1");
            }
        }
    }
}