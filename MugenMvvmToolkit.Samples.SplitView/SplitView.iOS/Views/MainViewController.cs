using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;
using MugenMvvmToolkit.Interfaces.ViewModels;
using SidebarNavigation;
using SplitView.Portable.ViewModels;
using UIKit;

namespace SplitView.iOS.Views
{
    [Register("MainViewController")]
    public class MainViewController : MvvmViewController
    {
        #region Fields

        private IViewModel _content;

        #endregion

        #region Properties

        // the sidebar controller for the app
        public SidebarController SidebarController { get; private set; }

        public IViewModel Content
        {
            get { return _content; }
            set
            {
                if (value == _content)
                    return;
                _content = value;
                if (value == null)
                    SidebarController.ChangeContentView(new ItemViewController(true));
                else
                    SidebarController.ChangeContentView((UIViewController) ServiceProvider.ViewManager.GetOrCreateView(value));
            }
        }

        #endregion

        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            var menuViewController = new MenuViewController();
            menuViewController.SetBindingMemberValue(AttachedMembers.Object.Parent, this);
            // create a slideout navigation controller with the top navigation controller and the menu view controller
            SidebarController = new SidebarController(this, new ItemViewController(true), menuViewController)
            {
                HasShadowing = false,
                MenuWidth = 220,
                MenuLocation = MenuLocations.Left
            };
            this.Bind(nameof(Content)).To(nameof(MainViewModel.SelectedItem)).Build();
        }

        #endregion
    }
}