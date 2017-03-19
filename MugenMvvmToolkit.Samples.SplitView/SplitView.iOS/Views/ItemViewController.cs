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
        #region Fields

        private readonly bool _empty;

        #endregion

        #region Constructors

        public ItemViewController()
        {
        }

        public ItemViewController(bool empty)
        {
            _empty = empty;
        }

        #endregion

        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Gray;
            var label = new UILabel(new CGRect(View.Frame.Width / 2 - 20, View.Frame.Height / 2, 100, 50));
            View.AddSubview(label);

            if (_empty)
            {
                label.Text = "<--- Slide";
                label.SizeToFit();
            }
            else
            {
                label.Bind()
                    .To<ItemViewModel>(() => (vm, ctx) => vm.DisplayName)
                    .Build();
            }
        }

        #endregion
    }
}