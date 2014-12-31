using MugenMvvmToolkit.Attributes;
using OrderManager.Infrastructure;
using OrderManager.Portable.ViewModels;
using Xamarin.Forms;

namespace OrderManager.Views.Orders
{
    [ViewModel(typeof(EditorWrapperViewModel<>), WrapperManagerEx.OrderViewName)]
    public partial class OrderEditorView : TabbedPage
    {
        public OrderEditorView()
        {
            InitializeComponent();            
        }
    }
}