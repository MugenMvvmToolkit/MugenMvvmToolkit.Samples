using System.ComponentModel;
using Microsoft.Phone.Controls;
using MugenMvvmToolkit.WinPhone;

namespace OrderManager.WindowsPhone.Views
{
    public partial class MainPage : PhoneApplicationPage
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