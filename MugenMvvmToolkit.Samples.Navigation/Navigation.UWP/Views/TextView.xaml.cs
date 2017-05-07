using Windows.UI.Xaml.Controls;
using MugenMvvmToolkit.Attributes;
using Navigation.Portable.ViewModels;

namespace Navigation.UWP.Views
{
    [ViewModel(typeof(TabViewModel))]
    public sealed partial class TextView : UserControl
    {
        public TextView()
        {
            InitializeComponent();
        }
    }
}