using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Xamarin.Forms.Interfaces.Views;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class DialogView : ContentPage, IModalView
    {
        #region Constructors

        public DialogView()
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
