using Binding.Portable.ViewModels;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    [Register("AttachedMemberViewController")]
    public class AttachedMemberViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            var uiImageView = new UIImageView(View.Frame) { ContentMode = UIViewContentMode.ScaleAspectFit };
            View.Add(uiImageView);
            uiImageView.Bind("ImageUrl").To<AttachedMemberViewModel>(() => (vm, ctx) => vm.ImageUrl).Build();
        }

        #endregion
    }
}