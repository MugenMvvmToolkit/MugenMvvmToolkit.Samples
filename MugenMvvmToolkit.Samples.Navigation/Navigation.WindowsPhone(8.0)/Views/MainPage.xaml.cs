using System.ComponentModel;
using MugenMvvmToolkit.WinPhone;

namespace Navigation.WindowsPhone.Views
{
    public partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            PlatformExtensions.HandleMainPageOnBackKeyPress(base.OnBackKeyPress, e);
        }

        #endregion
    }
}