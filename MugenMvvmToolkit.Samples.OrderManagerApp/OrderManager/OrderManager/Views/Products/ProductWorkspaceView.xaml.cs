using MugenMvvmToolkit.Xamarin.Forms;
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
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion
    }
}