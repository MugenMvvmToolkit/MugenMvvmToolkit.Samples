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
                set.Bind(oneTimeTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .OneTime();
                set.Bind(oneWayTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .OneWay();
                set.Bind(oneWayDelayTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .OneWay()
                    .WithDelay(1000, true);
                set.Bind(oneWaySrcTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .OneWayToSource();
                set.Bind(twoWayTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .TwoWay();
                set.Bind(twoWayDelayTb, () => box => box.Text)
                    .To(() => vm => vm.Text)
                    .TwoWay()
                    .WithDelay(1000);
            }
        }
    }
}