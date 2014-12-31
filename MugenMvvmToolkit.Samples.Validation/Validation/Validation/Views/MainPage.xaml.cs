using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Validation.Views
{
    public partial class MainPage : ContentPage
    {
        #region Constructors

        public MainPage()
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
