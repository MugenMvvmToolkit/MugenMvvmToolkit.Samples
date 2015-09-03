using Xamarin.Forms;

namespace Binding.Views
{
    public partial class CollectionBindingView : ContentPage
    {
        #region Constructors

        public CollectionBindingView()
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
