using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class PageView : ContentPage
    {
        #region Constructors

        public PageView()
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
