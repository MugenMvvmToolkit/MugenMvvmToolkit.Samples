using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;

namespace OrderManager.Behaviors
{
    //NOTE: http://www.visuallylocated.com/post/2014/04/06/Using-a-behavior-to-control-the-ProgressIndicator-in-Windows-Phone-81-XAML-Apps.aspx
    public class ProgressBehavior : DependencyObject, IBehavior
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                typeof (string),
                typeof (ProgressBehavior),
                new PropertyMetadata(null, OnTextChanged));

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible",
                typeof (bool),
                typeof (ProgressBehavior),
                new PropertyMetadata(false, OnIsVisibleChanged));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof (object),
                typeof (ProgressBehavior),
                new PropertyMetadata(null, OnValueChanged));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool IsVisible
        {
            get { return (bool) GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public double? Value
        {
            get { return (double?) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
        }

        public void Detach()
        {
        }

        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var isvisible = (bool) e.NewValue;
            if (isvisible)
            {
                StatusBar.GetForCurrentView().ProgressIndicator.ShowAsync();
            }
            else
            {
                StatusBar.GetForCurrentView().ProgressIndicator.HideAsync();
            }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string text = string.Empty;
            if (e.NewValue != null)
            {
                text = e.NewValue.ToString();
            }
            StatusBar.GetForCurrentView().ProgressIndicator.Text = text;
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var val = (double?) e.NewValue;
            StatusBar.GetForCurrentView().ProgressIndicator.ProgressValue = val;
        }
    }
}