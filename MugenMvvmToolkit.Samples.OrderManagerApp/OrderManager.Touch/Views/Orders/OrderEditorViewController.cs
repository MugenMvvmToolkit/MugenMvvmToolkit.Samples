using Foundation;
using UIKit;
using MugenMvvmToolkit.iOS.Views;

namespace OrderManager.Touch.Views.Orders
{
    [Register("OrderEditorViewController")]
    public class OrderEditorViewController : MvvmTabBarController
    {
        #region Overrides of MvvmTabBarController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewControllers = new UIViewController[]
            {
                new OrderInfoEditorViewController(),
                new OrderProductEditorViewController()
            };
        }

        #endregion
    }
}