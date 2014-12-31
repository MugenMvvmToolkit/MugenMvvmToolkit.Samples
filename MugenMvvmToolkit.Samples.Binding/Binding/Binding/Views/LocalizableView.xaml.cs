using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class LocalizableView : ContentPage
    {
        #region Constructors

        public LocalizableView()
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
