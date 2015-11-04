 // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SplitView.XamForms.WinRT.Phone
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new XamForms.App());
        }

        #endregion
    }
}