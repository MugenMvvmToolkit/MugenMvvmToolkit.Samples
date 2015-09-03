using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace Validation.Views
{
    public partial class UserWorkspaceView : ContentPage
    {
        #region Constructors

        public UserWorkspaceView()
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
