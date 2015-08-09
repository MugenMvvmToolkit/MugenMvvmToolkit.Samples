using Windows.UI.Xaml.Controls.Primitives;
using MugenMvvmToolkit.WinRT.Interfaces.Views;
using MugenMvvmToolkit.WinRT.Models;

namespace Navigation.UniversalApp.Views
{
    public sealed partial class WrapperWindowView : IPopupView
    {
        #region Constructors

        public WrapperWindowView()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IPopupView

        public void InitializePopup(Popup popup, PopupSettings settings)
        {
        }

        #endregion
    }
}