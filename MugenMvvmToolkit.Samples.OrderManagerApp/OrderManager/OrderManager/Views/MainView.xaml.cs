using MugenMvvmToolkit;
using Xamarin.Forms;

namespace OrderManager.Views
{
    public partial class MainView : ContentPage
    {
        #region Constructors

        public MainView()
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