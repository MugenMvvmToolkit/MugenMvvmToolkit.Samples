using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Attributes;

namespace ApiExamples.Views
{
    [ViewModel(typeof(ContentViewModel), Constants.ContentFormContentManager)]
    public partial class ContentFormContentManager : Form
    {
        public ContentFormContentManager()
        {
            InitializeComponent();
        }
    }
}