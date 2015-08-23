using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using Validation.Portable.ViewModels;

namespace Validation.WinForms.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(dataAnnotButton)
                   .To(() => m => m.ShowAnnotationCommand);
                set.Bind(validatorButton)
                   .To(() => m => m.ShowUserEditorCommand);
            }
        }
    }
}