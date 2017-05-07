using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class ResultView : Form
    {
        #region Constructors

        public ResultView()
        {
            InitializeComponent();
            using (var set = new BindingSet<ResultViewModel>())
            {
                set.Bind(resultTb).To(nameof(ResultViewModel.Result)).TwoWay();
                set.Bind(closeBtn).To(nameof(ResultViewModel.CloseCommand));
            }
        }

        #endregion
    }
}