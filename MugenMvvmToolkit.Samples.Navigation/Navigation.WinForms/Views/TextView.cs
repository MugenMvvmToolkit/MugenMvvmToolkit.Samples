using System.Windows.Forms;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    [ViewModel(typeof(TabViewModel))]
    public partial class TextView : UserControl
    {
        public TextView()
        {
            InitializeComponent();
            button1.Bind(nameof(button1.Click)).To<TabViewModel>(() => (vm, ctx) => vm.CloseCommand).Build();
            showOpenedBtn.Bind(nameof(showOpenedBtn.Click)).To<TabViewModel>(() => (vm, ctx) => vm.ShowOpenedViewModelsCommand).Build();
            textLb.Bind(nameof(textLb.Text)).To<TabViewModel>(() => (vm, ctx) => vm.Text).Build();
        }
    }
}