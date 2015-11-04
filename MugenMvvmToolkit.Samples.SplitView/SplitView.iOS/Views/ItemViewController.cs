using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.iOS.Views;
using SplitView.Portable.ViewModels;
using UIKit;

namespace SplitView.iOS.Views
{
    [Register("ItemViewController")]
    public class ItemViewController : MvvmViewController
    {
        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            var label = new UILabel(new CGRect(View.Frame.Width / 2 - 20, View.Frame.Height / 2, 100, 50));
            View.AddSubview(label);

            label.Bind()
                .To<ItemViewModel>(() => (vm, ctx) => vm.DisplayName)
                .Build();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }

        #endregion
    }
}