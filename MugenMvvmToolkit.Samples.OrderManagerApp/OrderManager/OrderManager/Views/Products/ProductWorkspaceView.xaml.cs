using MugenMvvmToolkit;
using Xamarin.Forms;

namespace OrderManager.Views.Products
{
    public partial class ProductWorkspaceView : ContentPage
    {
        #region Constructors

        public ProductWorkspaceView()
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