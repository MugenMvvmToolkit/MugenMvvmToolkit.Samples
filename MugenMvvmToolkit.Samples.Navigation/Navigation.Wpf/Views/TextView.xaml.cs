using System.Windows.Controls;
using MugenMvvmToolkit.Attributes;
using Navigation.Portable.ViewModels;

namespace Navigation.Wpf.Views
{
    [ViewModel(typeof(TabViewModel))]
    public partial class TextView : UserControl
    {
        #region Constructors

        public TextView()
        {
            InitializeComponent();
        }

        #endregion
    }
}