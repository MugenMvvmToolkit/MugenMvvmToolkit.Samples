using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            button1.Bind().To<FirstViewModel>(() => m => m.CloseCommand).Build();
        }
    }
}