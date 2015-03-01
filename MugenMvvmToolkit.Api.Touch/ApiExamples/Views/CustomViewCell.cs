using Foundation;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Views
{
    public class CustomViewCell : UITableViewCellBindable
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