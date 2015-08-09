using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace OrderManager.Views.Orders
{
    public partial class OrderWorkspaceView : ContentPage
    {
        #region Constructors

        public OrderWorkspaceView()
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