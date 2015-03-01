using System.Drawing;
using Foundation;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Views
{
    public class CollectionViewCell : UICollectionViewCellBindable
    {
        #region Constructors

        [Export("initWithFrame:")]
        public CollectionViewCell(RectangleF frame)
            : base(frame)
        {
            BackgroundView = new UIView {BackgroundColor = UIColor.Yellow};
            SelectedBackgroundView = new UIView {BackgroundColor = UIColor.Green};
            Label = new UILabel(new RectangleF(0, 0, frame.Width, frame.Height))
            {
                AdjustsFontSizeToFitWidth = true
            };
            ContentView.AddSubview(Label);
        }

        #endregion

        #region Properties

        public UILabel Label { get; private set; }

        #endregion
    }
}