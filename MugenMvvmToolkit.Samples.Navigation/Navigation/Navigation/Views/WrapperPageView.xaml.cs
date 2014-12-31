using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class WrapperPageView : ContentPage
    {
        #region Constructors

        public WrapperPageView()
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
