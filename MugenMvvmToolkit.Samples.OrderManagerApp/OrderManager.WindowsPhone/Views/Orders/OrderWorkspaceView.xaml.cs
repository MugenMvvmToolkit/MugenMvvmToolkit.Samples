using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace OrderManager.WindowsPhone.Views.Orders
{
    public partial class OrderWorkspaceView : PhoneApplicationPage
    {
        #region Constructors

        public OrderWorkspaceView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SearchClick(object sender, EventArgs e)
        {
            HeaderPanel.Visibility = Visibility.Collapsed;
            FilterTb.Visibility = Visibility.Visible;
            FilterTb.Focus();
        }

        private void FilterTbOnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilterTb.Text))
                return;
            HeaderPanel.Visibility = Visibility.Visible;
            FilterTb.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}