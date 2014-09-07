using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views
{
    [ViewModel(typeof(TabViewModel), Constants.CollectionViewManager)]
    public partial class CollectionViewManagerForm : Form
    {
        public CollectionViewManagerForm()
        {
            InitializeComponent();            
        }
    }
}