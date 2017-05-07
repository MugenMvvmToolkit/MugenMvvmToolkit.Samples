using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Attributes;
using UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using MugenMvvmToolkit.Interfaces.Models;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("TextViewController")]
    [ViewModel(typeof(PageViewModel))]
    [ViewModel(typeof(BackgroundViewModel))]
    public class TextViewController : MvvmViewController
    {
        #region Constructors

        public TextViewController()
        {
            //to bind title before load view.
            this.Bind(nameof(Title)).To(nameof(IHasDisplayName.DisplayName)).Build();
        }

        #endregion

        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<NavigationViewModelBase>())
            {
                var textLb = new UILabel(new CGRect(0, 70, View.Frame.Width, 30)) { TextAlignment = UITextAlignment.Center };
                set.Bind(textLb).To("Text");
                View.AddSubview(textLb);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 100, View.Frame.Width, 30);
                button.SetTitle("Show Opened View Models", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.ShowOpenedViewModelsCommand);
                View.AddSubview(button);

                button = UIButton.FromType(UIButtonType.System);
                button.Frame = new CGRect(0, 130, View.Frame.Width, 30);
                button.SetTitle("Close", UIControlState.Normal);
                set.Bind(button).To(() => (vm, ctx) => vm.CloseCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}