using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views
{
    [ViewModel(typeof(TabViewModel), Constants.TabViewItemTeplate)]
    public partial class TabFormItemTemplate : Form
    {
        public TabFormItemTemplate()
        {
            InitializeComponent();
        }
    }
}