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
                    .To(() => vm => vm.CanExecuteCommand)
                    .TwoWay();
                set.Bind(button1)
                    .To(() => vm => vm.Command)
                    .WithCommandParameter("1");
                set.Bind(button2)
                    .To(() => vm => vm.Command)
                    .ToggleEnabledState(false)
                    .WithCommandParameter("2");
                set.Bind(event1Tb, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(null));
                set.Bind(event2Tb, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(BindingSyntaxEx.Self<TextBox>().Text));
                set.Bind(event3Tb, "TextChanged")
                    .ToAction(() => vm => vm.EventMethod(BindingSyntaxEx.EventArgs<object>()));
                set.Bind(event4Tb, "TextChanged")
                    .ToAction(() => vm => vm.EventMethodMultiParams(BindingSyntaxEx.Self<TextBox>().Text, BindingSyntaxEx.EventArgs<object>()));
            }
        }
    }
}