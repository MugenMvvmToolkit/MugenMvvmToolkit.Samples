using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.WinForms.Binding;

namespace Navigation.WinForms.Views
{
    public partial class WrapperWindowView : Form
    {
        public WrapperWindowView()
        {
            InitializeComponent();
            this.Bind(AttachedMembers.Control.Content).To<IWrapperViewModel>(() => (vm, ctx) => vm.ViewModel).Build();
        }
    }
}