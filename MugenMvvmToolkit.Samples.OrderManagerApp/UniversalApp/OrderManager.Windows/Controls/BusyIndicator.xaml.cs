using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace OrderManager.Controls
{
    [ContentProperty(Name = "Content")]
    public sealed partial class BusyIndicator : UserControl
    {
        #region Dependency properties

        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof (bool),
            typeof (BusyIndicator), new PropertyMetadata(default(bool), OnIsBusyChanged));

        public static readonly DependencyProperty BusyContentProperty = DependencyProperty.Register("BusyContent",
            typeof (object), typeof (BusyIndicator), new PropertyMetadata(default(object), OnBusyContentChanged));

        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof (object), typeof (BusyIndicator),
                new PropertyMetadata(default(object), OnContentChanged));

        public bool IsBusy
        {
            get { return (bool) GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public object BusyContent
        {
            get { return GetValue(BusyContentProperty); }
            set { SetValue(BusyContentProperty, value); }
        }

        public new object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        private static void OnBusyContentChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var busyIndicator = (BusyIndicator) dependencyObject;
            busyIndicator.BusyContentPresenter.Content = args.NewValue;
        }

        private static void OnIsBusyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var busyIndicator = (BusyIndicator) dependencyObject;
            if ((bool) args.NewValue)
            {
                busyIndicator.BusyGrid.Visibility = Visibility.Visible;
                busyIndicator.ContentPresenter.IsEnabled = false;
            }
            else
            {
                busyIndicator.BusyGrid.Visibility = Visibility.Collapsed;
                busyIndicator.ContentPresenter.IsEnabled = true;
            }
        }

        private static void OnContentChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var busyIndicator = (BusyIndicator) dependencyObject;
            busyIndicator.ContentPresenter.Content = args.NewValue;
        }

        #endregion

        #region Constructors

        public BusyIndicator()
        {
            InitializeComponent();
        }

        #endregion
    }
}