//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Navigation.Touch.Views
{
    [Register("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        MonoTouch.UIKit.UITabBar TabBar { get; set; }

        [Outlet]
        MonoTouch.UIKit.UIToolbar ToolBar { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (ToolBar != null)
            {
                ToolBar.Dispose();
                ToolBar = null;
            }

            if (TabBar != null)
            {
                TabBar.Dispose();
                TabBar = null;
            }
        }
    }
}