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
        #region Constructors

        public BindingExpressionView()
        {
            InitializeComponent();

            using (var set = new BindingSet<BindingExpressionViewModel>())
            {
                set.Bind(textTb).To(() => (vm, ctx) => vm.Text).TwoWay();
                set.Bind(linqCountLabel)
                    .To(() => (vm, ctx) => vm.Text.OfType<char>().Count(x => x == 'a'));
                set.Bind(extMethodLabel)
                    .To(() => (vm, ctx) => vm.Text.ExtensionMethod(vm.Text.Count()));
                set.Bind(linqSecondCharLabel)
                    .To(() => (vm, ctx) => vm.Text.OfType<char>().Skip(1).FirstOrDefault());
                set.Bind(conditionLabel)
                    .To(() => (vm, ctx) => string.IsNullOrEmpty(vm.Text) ? "String is empty" : "String is not empty");
                set.Bind(arithmeticLabel)
                    .To(() => (vm, ctx) => vm.Text.Count() + 100 + vm.Text.GetHashCode());
                set.BindFromExpression(nullConditionalLabel, "Text NullableText?.Trim()?.Length ?? -1");
                set.BindFromExpression(interpolatedLabel, "Text $'{Text} length {Text.Length}'");
                /*set.Bind(interpolatedLabel)
                    .To(() => (vm, ctx) => $"{vm.Text} length {vm.Text.Length}");*/ //<-- Visual studio >= 2015
            }
        }

        #endregion
    }
}