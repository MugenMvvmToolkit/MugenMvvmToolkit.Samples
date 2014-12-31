using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class BindingModeView : ContentPage
    {
        #region Constructors

        public BindingModeView()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed();
        }

        #endregion
    }
}
