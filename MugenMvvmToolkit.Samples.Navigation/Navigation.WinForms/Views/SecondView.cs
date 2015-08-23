using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class SecondView : UserControl
    {
        public SecondView()
        {
            InitializeComponent();
            button1.Bind().To<SecondViewModel>(() => m => m.CloseCommand).Build();
        }
    }
}