using CoreGraphics;
using Foundation;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Interfaces.Views;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("FirstViewController")]
    public class FirstViewController : MvvmViewController, ITabView
    {
        #region Constructors

        public FirstViewController()
        {
            //to bind title befor load view.
            this.SetBindings("Title DisplayName");
        }

        #endregion

        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<SecondViewModel>())
            {
                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 70, View.Frame.Width, 30);
                button.SetTitle("Close from view model (First view)", UIControlState.Normal);
                set.Bind(button).To(() => model => model.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}