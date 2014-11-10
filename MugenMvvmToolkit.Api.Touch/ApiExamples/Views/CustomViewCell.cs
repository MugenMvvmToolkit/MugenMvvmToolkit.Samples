using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Views;

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