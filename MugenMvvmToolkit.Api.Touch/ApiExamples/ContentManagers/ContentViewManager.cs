using CoreGraphics;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using UIKit;

namespace ApiExamples.ContentManagers
{
    public class ContentViewManager : ContentViewManagerBase<UIView, UIView>
    {
        #region Fields

        public static readonly ContentViewManager Instance = new ContentViewManager();

        #endregion

        #region Constructors

        private ContentViewManager()
        {
        }

        #endregion

        #region Overrides of ContentViewManagerBase<UIView,UIView>

        protected override void SetContent(UIView view, UIView content)
        {
            if (content == null)
                view.ClearSubViews();
            else
            {
                content.Frame = new CGRect(0, view.Frame.Height / 2, view.Frame.Width, 30);
                view.AddSubviewEx(content);
            }
        }

        #endregion
    }
}