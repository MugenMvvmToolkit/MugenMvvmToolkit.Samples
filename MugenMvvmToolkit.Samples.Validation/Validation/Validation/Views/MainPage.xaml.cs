using MugenMvvmToolkit.Xamarin.Forms;
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
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion
    }
}
