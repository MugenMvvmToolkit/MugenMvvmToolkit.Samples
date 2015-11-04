using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Binding.WinForms.Views
{
    public partial class BindingModeView : Form
    {
        public BindingModeView()
        {
            InitializeComponent();

            using (var set = new BindingSet<BindingModeViewModel>())
            {
                set.Bind(oneTimeTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .OneTime();
                set.Bind(oneWayTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .OneWay();
                set.Bind(oneWayDelayTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .OneWay()
                    .WithDelay(1000, true);
                set.Bind(oneWaySrcTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .OneWayToSource();
                set.Bind(twoWayTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .TwoWay();
                set.Bind(twoWayDelayTb)
                    .To(() => (vm, ctx) => vm.Text)
                    .TwoWay()
                    .WithDelay(1000);
            }
        }
    }
}