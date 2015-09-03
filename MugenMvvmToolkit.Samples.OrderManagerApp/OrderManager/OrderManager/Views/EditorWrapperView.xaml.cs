using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace OrderManager.Views
{
    public partial class EditorWrapperView : ContentPage
    {
        #region Constructors

        public EditorWrapperView()
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
