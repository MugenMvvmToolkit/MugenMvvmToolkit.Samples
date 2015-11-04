using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace SplitView.XamForms.Views
{
    public partial class MainView : MasterDetailPage
    {
        #region Constructors

        public MainView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            IsPresented = false;
        }

        #endregion
    }
}