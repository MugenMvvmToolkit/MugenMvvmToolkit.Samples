using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class BackgroundView : ContentPage
    {
        #region Constructors

        public BackgroundView()
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
