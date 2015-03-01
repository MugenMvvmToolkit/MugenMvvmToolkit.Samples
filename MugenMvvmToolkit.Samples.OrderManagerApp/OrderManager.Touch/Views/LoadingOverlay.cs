using System;
using CoreGraphics;
using UIKit;

namespace OrderManager.Touch.Views
{
    /// <summary>
    ///     Source http://developer.xamarin.com/recipes/ios/standard_controls/popovers/display_a_loading_message/
    /// </summary>
    public class LoadingOverlay : UIView
    {
        // control declarations
        private UIActivityIndicatorView activitySpinner;
        private UILabel loadingLabel;

        public LoadingOverlay(CGRect frame)
            : base(frame)
        {
            // configurable bits
            BackgroundColor = UIColor.Black;
            Alpha = 0;
            AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

            nfloat labelHeight = 22;
            var labelWidth = Frame.Width - 20;

            // derive the center x and y
            var centerX = Frame.Width / 2;
            var centerY = Frame.Height / 2;

            // create the activity spinner, center it horizontall and put it 5 points above center x
            activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            activitySpinner.Frame = new CGRect(
                centerX - (activitySpinner.Frame.Width / 2),
                centerY - activitySpinner.Frame.Height - 20,
                activitySpinner.Frame.Width,
                activitySpinner.Frame.Height);
            activitySpinner.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
            AddSubview(activitySpinner);
            activitySpinner.StartAnimating();

            // create and configure the "Loading Data" label
            loadingLabel = new UILabel(new CGRect(
                centerX - (labelWidth / 2),
                centerY + 20,
                labelWidth,
                labelHeight
                ));
            loadingLabel.BackgroundColor = UIColor.Clear;
            loadingLabel.TextColor = UIColor.White;
            loadingLabel.Text = "Loading Data...";
            loadingLabel.TextAlignment = UITextAlignment.Center;
            loadingLabel.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
            AddSubview(loadingLabel);
        }

        public void Show(UIView target)
        {
            target.Add(this);
            Animate(0.25, () => { Alpha = 0.5f; });
        }

        /// <summary>
        ///     Fades out the control and then removes it from the super view
        /// </summary>
        public void Hide()
        {
            Animate(
                0.5, // duration
                () => { Alpha = 0; },
                () => { RemoveFromSuperview(); }
                );
        }

        public string BusyMessage
        {
            get { return loadingLabel.Text; }
            set
            {
                if (value != null)
                    loadingLabel.Text = value;
            }
        }
    };
}