using System.Windows;
using Microsoft.Phone.Controls;

namespace OrderManager.WindowsPhone.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Terminate();
        }

        #endregion
    }
}