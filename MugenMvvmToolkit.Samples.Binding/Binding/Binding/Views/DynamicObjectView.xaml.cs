using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class DynamicObjectView : ContentPage
    {
        #region Constructors

        public DynamicObjectView()
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
