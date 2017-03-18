using Foundation;
using UIKit;

namespace ApiExamples.Views
{
    public class CustomViewCell : UITableViewCell
    {
        #region Constructors

        public CustomViewCell(NSString cellId)
            : base(UITableViewCellStyle.Subtitle, cellId)
        {
            ContentView.BackgroundColor = UIColor.Green;
        }

        #endregion
    }
}