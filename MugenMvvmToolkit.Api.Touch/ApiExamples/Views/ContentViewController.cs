using ApiExamples.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace ApiExamples.Views
{
    [Register("ContentViewController")]
    public class ContentViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<ContentViewModel>())
            {
                set.Bind(View, AttachedMemberConstants.Content).To(model => model.ViewModel);
                set.BindFromExpression(View, "ContentTemplate $labelItemTemplate");
                set.BindFromExpression(View, "ContentViewManager $contentViewManager");
            }
        }

        #endregion
    }
}