using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class CommandBindingView : ContentPage
    {
        #region Constructors

        public CommandBindingView()
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
