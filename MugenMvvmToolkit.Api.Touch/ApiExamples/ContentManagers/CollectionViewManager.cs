using CoreGraphics;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using UIKit;

namespace ApiExamples.ContentManagers
{
    public class CollectionViewManager : CollectionViewManagerBase<UIView, UIView>
    {
        #region Fields

        public static readonly CollectionViewManager Instance = new CollectionViewManager();

        #endregion

        #region Constructors

        private CollectionViewManager()
        {
        }

        #endregion

        #region Overrides of CollectionViewManagerBase<UIView,UIView>

        /// <summary>
        ///     Inserts an item to the specified index.
        /// </summary>
        protected override void Insert(UIView view, int index, UIView item)
        {
            int length = view.Subviews.Length;
            item.Frame = new CGRect(20, length * 30 + 80, view.Frame.Width - 40, 30);
            view.AddSubviewEx(item);
        }

        /// <summary>
        ///     Removes an item.
        /// </summary>
        protected override void RemoveAt(UIView view, int index)
        {
            view.Subviews[index].RemoveFromSuperviewEx();
        }

        /// <summary>
        ///     Removes all items.
        /// </summary>
        protected override void Clear(UIView view)
        {
            view.ClearSubViews();
        }

        #endregion
    }
}