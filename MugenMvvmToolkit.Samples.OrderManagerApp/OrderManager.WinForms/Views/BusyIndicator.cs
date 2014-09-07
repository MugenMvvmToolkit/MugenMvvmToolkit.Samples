using System.Windows.Forms;

namespace OrderManager.WinForms.Views
{
    public partial class BusyIndicator : UserControl
    {
        #region Constructors

        public BusyIndicator()
        {
            InitializeComponent();
            Anchor = AnchorStyles.None;
        }

        #endregion

        #region Properties

        public object BusyMessage
        {
            get { return Text; }
            set { label1.Text = value == null ? null : value.ToString(); }
        }

        #endregion
    }
}