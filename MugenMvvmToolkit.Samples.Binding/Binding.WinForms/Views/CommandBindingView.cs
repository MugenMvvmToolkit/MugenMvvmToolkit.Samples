using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class CommandBindingView : Form
    {
        public CommandBindingView()
        {
            InitializeComponent();

            using (var set = new BindingSet<CommandBindingViewModel>())
            {
                set.Bind(canExecuteCheckBox)
                    .To(() => (vm, ctx) => vm.CanExecuteCommand)
                    .TwoWay();
                set.Bind(button1)
                    .To(() => (vm, ctx) => vm.Command)
                    .WithCommandParameter("1");
                set.Bind(button2)
                    .To(() => (vm, ctx) => vm.Command)
                    .ToggleEnabledState(false)
                    .WithCommandParameter("2");
                set.Bind(event1Tb, "TextChanged")
                    .ToAction(() => (vm, ctx) => vm.EventMethod(null));
                set.Bind(event2Tb, "TextChanged")
                    .ToAction(() => (vm, ctx) => vm.EventMethod(ctx.Self().Text));
                set.Bind(event3Tb, "TextChanged")
                    .ToAction(() => (vm, ctx) => vm.EventMethod(ctx.EventArgs<object>()));
                set.Bind(event4Tb, "TextChanged")
                    .ToAction(() => (vm, ctx) => vm.EventMethodMultiParams(ctx.Self().Text, ctx.EventArgs<object>()));
            }
        }
    }
}