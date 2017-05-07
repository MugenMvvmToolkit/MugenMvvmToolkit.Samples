using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class ResultView : ContentPage
    {
        #region Constructors

        public ResultView()
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
