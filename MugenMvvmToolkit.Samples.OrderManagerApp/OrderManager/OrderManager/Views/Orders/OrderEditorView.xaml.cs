using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Attributes;
using OrderManager.Infrastructure;
using OrderManager.Portable.ViewModels;
using Xamarin.Forms;

namespace OrderManager.Views.Orders
{
    [ViewModel(typeof(EditorWrapperViewModel<>), WrapperManagerEx.OrderViewName)]
    public partial class OrderEditorView : TabbedPage
    {
        #region Constructors

        public OrderEditorView()
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