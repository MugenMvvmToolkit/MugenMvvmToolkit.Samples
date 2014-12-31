using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class BindingResourcesView : ContentPage
    {
        #region Constructors

        public BindingResourcesView()
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
