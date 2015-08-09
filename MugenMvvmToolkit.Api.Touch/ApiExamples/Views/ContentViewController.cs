using ApiExamples.ContentManagers;
using ApiExamples.Templates;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

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
                set.Bind(View, AttachedMemberConstants.Content).To(() => model => model.ViewModel);
                View.SetBindingMemberValue(AttachedMembers.UIView.ContentTemplateSelector, LabelItemTemplateSelector.Instance);
                View.SetBindingMemberValue(AttachedMembers.UIView.ContentViewManager, ContentViewManager.Instance);
            }
        }

        #endregion
    }
}