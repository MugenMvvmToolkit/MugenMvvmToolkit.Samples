using MugenMvvmToolkit.Attributes;
using Navigation.Portable.ViewModels;
using Xamarin.Forms;

namespace Navigation.Views
{
    [ViewModel(typeof(TabViewModel))]
    public partial class TextView : ContentView
    {
        public TextView()
        {
            InitializeComponent();
        }
    }
}
